using MeetingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;


namespace MeetingApp
{
    public class DatabaseHelper
    {
        private string connectionString;
        public DatabaseHelper(string connectionString) {
            this.connectionString = connectionString;
        }

        public bool TestConnection() {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open;
                }
            } catch {
                return false;
            }
        }

        public User ValidateUser(string username, string password) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT userID, isAdmin, FirstName, LastName FROM users WHERE username = @username AND userPassword = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    int userId = reader.GetInt32(reader.GetOrdinal("userID"));
                    byte isAdmin = reader.GetByte(reader.GetOrdinal("isAdmin"));
                    string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                    string fullName = $"{firstName} {lastName}";
                    return new User { UserID = userId, IsAdmin = isAdmin, FullName = fullName };
                } else {
                    return null;
                }
            }
        }


        public string GetEmailByUsername(string username) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT email FROM users WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                object result = command.ExecuteScalar();

                return result != null ? result.ToString() : null;
            }
        }

        public string GetPassByUsername(string username) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT userPassword FROM users WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                object result = command.ExecuteScalar();

                return result != null ? result.ToString() : null;
            }
        }


        public bool IsAdmin(int userID) {
            bool isAdmin = false;

            string query = "SELECT isAdmin FROM users WHERE userID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result is bool) {
                    isAdmin = (bool)result;
                }
            }

            return isAdmin;
        }

        public void RegisterUser(string username, string firstName, string lastName, string email, string companyName, string title, string phoneNumber, string password, byte isAdmin, string position) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "INSERT INTO users (username, firstName, lastName, email, companyName, title, phoneNumber, userPassword, isAdmin ,position) VALUES (@username, @firstName, @lastName, @email, @companyName, @title, @phoneNumber, @password, @isAdmin, @position)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@companyName", companyName);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@isAdmin", isAdmin);
                command.Parameters.AddWithValue("@position", position);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool UpdateUser(int userID, string username, string firstName, string lastName, string email, string companyName, string title, string phoneNumber, string password, byte isAdmin, string position) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"
            UPDATE users 
            SET username = @username, 
                firstName = @firstName, 
                lastName = @lastName, 
                email = @email, 
                companyName = @companyName, 
                title = @title, 
                phoneNumber = @phoneNumber, 
                userPassword = @password, 
                isAdmin = @isAdmin, 
                position = @position
            WHERE userID = @userID";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@companyName", companyName);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@isAdmin", isAdmin);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@userID", userID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // Eğer etkilenen satır sayısı 1'den büyükse güncelleme başarılı olmuştur
                }
            }
        }

        public bool DeleteUser(int userId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                SqlTransaction transaction = null;

                try {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // 1. Adım: Zimmetli tüm envanter öğelerini güncelle (userID'yi NULL yap)
                    string updateInventoryQuery = "UPDATE inventory SET userID = NULL WHERE userID = @UserID";
                    using (SqlCommand cmd1 = new SqlCommand(updateInventoryQuery, conn, transaction)) {
                        cmd1.Parameters.AddWithValue("@UserID", userId);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2. Adım: MeetingParticipants tablosundan kullanıcıya ait tüm katılımcıları sil
                    string query1 = "DELETE FROM MeetingParticipants WHERE ParticipantType = 'User' AND ParticipantID = @UserID";
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn, transaction)) {
                        cmd1.Parameters.AddWithValue("@UserID", userId);
                        cmd1.ExecuteNonQuery();
                    }

                    // 3. Adım: Users tablosundan kullanıcıyı sil
                    string query2 = "DELETE FROM users WHERE userID = @UserID";
                    using (SqlCommand cmd2 = new SqlCommand(query2, conn, transaction)) {
                        cmd2.Parameters.AddWithValue("@UserID", userId);
                        int result = cmd2.ExecuteNonQuery();

                        // İşlemleri commit et
                        transaction.Commit();

                        // Eğer etkilenen satır sayısı 1 ise silme başarılı olmuştur
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata durumunda işlemleri geri al (rollback)
                    transaction?.Rollback();
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        public bool isIdentyusername(string username) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        public bool AddCompany(string companyName, string address, string phone, string fieldsOfActivity, byte[] logo, string email) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "INSERT INTO Companies (Name, Address, Phone, FieldsOfActivity, Logo, Email) VALUES (@Name, @Address, @Phone, @FieldsOfActivity, @Logo, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@Name", companyName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@FieldsOfActivity", fieldsOfActivity);

                        // Logo parametresini kontrol et
                        if (logo != null) {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = logo;
                        } else {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        command.Parameters.AddWithValue("@Email", email);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool AddCandidateCompany(string companyName, string address, string phone, string fieldsOfActivity, byte[] logo, string email, int point) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "INSERT INTO CandidateCompanies (Name, Address, Phone, FieldsOfActivity, Logo, Email ,Points) VALUES (@Name, @Address, @Phone, @FieldsOfActivity, @Logo, @Email, @Point)";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@Name", companyName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@FieldsOfActivity", fieldsOfActivity);

                        // Logo parametresini kontrol et
                        if (logo != null) {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = logo;
                        } else {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Point", point);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool UpdateCompany(int companyId, string companyName, string address, string phone, string fieldsOfActivity, byte[] logo, string email) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    // Şirketi güncellemek için SQL UPDATE sorgusu
                    string query = "UPDATE Companies SET Name = @Name, Address = @Address, Phone = @Phone, FieldsOfActivity = @FieldsOfActivity, Logo = @Logo, Email = @Email WHERE CompanyID = @CompanyID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@Name", companyName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@FieldsOfActivity", fieldsOfActivity);

                        // Logo parametresini kontrol et
                        if (logo != null) {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = logo;
                        } else {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@CompanyID", companyId);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public bool UpdateCandidateCompany(int companyId, string companyName, string address, string phone, string fieldsOfActivity, byte[] logo, string email, int point) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    // Şirketi güncellemek için SQL UPDATE sorgusu
                    string query = "UPDATE CandidateCompanies SET Name = @Name, Address = @Address, Phone = @Phone, FieldsOfActivity = @FieldsOfActivity, Logo = @Logo, Email = @Email, Points = @point WHERE CompanyID = @CompanyID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@Name", companyName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@FieldsOfActivity", fieldsOfActivity);

                        // Logo parametresini kontrol et
                        if (logo != null) {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = logo;
                        } else {
                            command.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@point", point);
                        command.Parameters.AddWithValue("@CompanyID", companyId);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool DeleteCandidateCompany(int companyId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    // Şirketi güncellemek için SQL UPDATE sorgusu
                    string query = "DELETE FROM CandidateCompanies WHERE CompanyID = @CompanyID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@CompanyID", companyId);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool DeleteCompany(int companyId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlTransaction transaction = null;

                try {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // 1. Adım: Employees tablosundan bu şirkete bağlı çalışanları silmeden önce
                    // MeetingParticipants tablosundan bu çalışanlara bağlı katılımcıları sil
                    string query1 = "DELETE FROM MeetingParticipants WHERE ParticipantType = 'Employee' AND ParticipantID IN (SELECT EmployeeID FROM Employees WHERE CompanyID = @CompanyID)";
                    using (SqlCommand command1 = new SqlCommand(query1, connection, transaction)) {
                        command1.Parameters.AddWithValue("@CompanyID", companyId);
                        command1.ExecuteNonQuery();
                    }

                    // 2. Adım: MeetingParticipants tablosundan şirketle ilgili katılımcıları sil
                    string query2 = "DELETE FROM MeetingParticipants WHERE ParticipantType = 'Company' AND ParticipantID = @CompanyID";
                    using (SqlCommand command2 = new SqlCommand(query2, connection, transaction)) {
                        command2.Parameters.AddWithValue("@CompanyID", companyId);
                        command2.ExecuteNonQuery();
                    }

                    // 3. Adım: Employees tablosundan bu şirkete bağlı tüm çalışanları sil
                    string query3 = "DELETE FROM Employees WHERE CompanyID = @CompanyID";
                    using (SqlCommand command3 = new SqlCommand(query3, connection, transaction)) {
                        command3.Parameters.AddWithValue("@CompanyID", companyId);
                        command3.ExecuteNonQuery();
                    }

                    // 4. Adım: Şirketi Companies tablosundan sil
                    string query4 = "DELETE FROM Companies WHERE CompanyID = @CompanyID";
                    using (SqlCommand command4 = new SqlCommand(query4, connection, transaction)) {
                        command4.Parameters.AddWithValue("@CompanyID", companyId);
                        int result = command4.ExecuteNonQuery();

                        // İşlemleri commit et
                        transaction.Commit();

                        // Eğer etkilenen satır sayısı 1 ise silme başarılı olmuştur
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata durumunda işlemleri geri al (rollback)
                    transaction?.Rollback();
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }



        public DataRow GetCompanyById(int companyId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "SELECT Name, Address, Phone, FieldsOfActivity, Logo, Email FROM Companies WHERE CompanyID = @CompanyID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@CompanyID", companyId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable companyTable = new DataTable();
                        adapter.Fill(companyTable);

                        if (companyTable.Rows.Count > 0) {
                            return companyTable.Rows[0];
                        } else {
                            return null;
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
        public DataRow GetCandidateCompanyById(int companyId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "SELECT Name, Address, Phone, FieldsOfActivity, Logo, Email, Points FROM CandidateCompanies WHERE CompanyID = @CompanyID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@CompanyID", companyId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable companyTable = new DataTable();
                        adapter.Fill(companyTable);

                        if (companyTable.Rows.Count > 0) {
                            return companyTable.Rows[0];
                        } else {
                            return null;
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }




        public DataTable GetCompanies() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT companyID, name, FieldsOfActivity FROM Companies ORDER BY name ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable companies = new DataTable();
                adapter.Fill(companies);
                return companies;
            }
        }


        public DataTable GetCandidateCompanies() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT CompanyID, Name, FieldsOfActivity, Phone, Points FROM CandidateCompanies ORDER BY name ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable companies = new DataTable();
                adapter.Fill(companies);
                return companies;
            }
        }

        public bool AddEmployee(string firstName, string lastName, string tcID, int companyID, string email, string phone, string title, string position) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "INSERT INTO Employees (firstname, lastname, companyID, email, phone, title, position,EmployeeTcID) VALUES (@FirstName, @LastName, @CompanyID, @Email, @Phone, @Title, @Position , @EmployeeTcID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.Add("@EmployeeTcID", SqlDbType.NVarChar).Value = (object)tcID ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = (object)title ?? DBNull.Value;
                cmd.Parameters.Add("@Position", SqlDbType.NVarChar).Value = (object)position ?? DBNull.Value;


                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }
        public bool UpdateEmployee(int employeeID, string firstName, string tcID, string lastName, int companyID, string email, string phone, string title, string position) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"UPDATE Employees 
                         SET FirstName = @FirstName, 
                             LastName = @LastName, 
                             CompanyID = @CompanyID, 
                             Email = @Email, 
                             Phone = @Phone, 
                             Title = @Title, 
                             Position = @Position,
                             EmployeeTcID = @EmployeeTcID
                         WHERE EmployeeID = @EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@EmployeeTcID", tcID);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }

        public bool DeleteEmployee(int employeeId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlTransaction transaction = null;

                try {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // 1. Adım: MeetingParticipants tablosundan çalışana ait katılımcıları sil
                    string query1 = "DELETE FROM MeetingParticipants WHERE ParticipantType = 'Employee' AND ParticipantID = @EmployeeID";
                    using (SqlCommand command1 = new SqlCommand(query1, connection, transaction)) {
                        command1.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command1.ExecuteNonQuery();
                    }

                    // 2. Adım: Employees tablosundan çalışanı sil
                    string query2 = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand command2 = new SqlCommand(query2, connection, transaction)) {
                        command2.Parameters.AddWithValue("@EmployeeID", employeeId);
                        int result = command2.ExecuteNonQuery();

                        // İşlemleri commit et
                        transaction.Commit();

                        // Eğer etkilenen satır sayısı 1 ise silme başarılı olmuştur
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata durumunda işlemleri geri al (rollback)
                    transaction?.Rollback();
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool AddAcademic(string firstName, string lastName, string email, string phone, string title, string position, string keyWords , string tcId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "INSERT INTO Academics (FirstName, LastName, Email, Phone, Title, Position, keyWords, tcID) VALUES (@FirstName, @LastName, @Email, @Phone, @Title, @Position ,@keyWords, @tcID)";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = (object)title ?? DBNull.Value;
                        command.Parameters.Add("@Position", SqlDbType.NVarChar).Value = (object)position ?? DBNull.Value;
                        command.Parameters.Add("@keyWords", SqlDbType.NVarChar).Value = (object)keyWords ?? DBNull.Value;
                        command.Parameters.Add("@tcID", SqlDbType.NVarChar).Value = (object)tcId ?? DBNull.Value;
                        int result = command.ExecuteNonQuery();

                        // Eğer etkilenen satır sayısı 1 ise ekleme başarılı
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata yönetimi burada yapılabilir (örneğin, loglama veya hata mesajı)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UpdateAcademic(int academicID, string firstName, string lastName, string email, string phone, string title, string position,string keyWords, string tcId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "UPDATE Academics SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Title = @Title, Position = @Position, keyWords = @keyWords, tcID = @tcID WHERE AcademicID = @AcademicID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@AcademicID", academicID);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Position", position);
                        command.Parameters.AddWithValue("@keyWords", keyWords);
                        command.Parameters.AddWithValue("@tcID", tcId);
                        int result = command.ExecuteNonQuery();

                        // Güncelleme başarılı olduysa result > 0 olacaktır
                        return result > 0;
                    }
                } catch (SqlException sqlEx) {
                    // SQL hatalarını loglama
                    MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } catch (Exception ex) {
                    // Genel hataları loglama
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool DeleteAcademic(int academicId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlTransaction transaction = null;

                try {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Önce MeetingParticipants tablosundan ilgili katılımcıyı sil
                    string query2 = "DELETE FROM MeetingParticipants WHERE ParticipantType = 'Academic' AND ParticipantID = @AcademicID";
                    using (SqlCommand command2 = new SqlCommand(query2, connection, transaction)) {
                        command2.Parameters.AddWithValue("@AcademicID", academicId);
                        command2.ExecuteNonQuery();
                    }

                    // Sonra Academics tablosundan akademisyeni sil
                    string query = "DELETE FROM Academics WHERE AcademicID = @AcademicID";
                    using (SqlCommand command = new SqlCommand(query, connection, transaction)) {
                        command.Parameters.AddWithValue("@AcademicID", academicId);
                        int result = command.ExecuteNonQuery();

                        // İşlemleri commit et
                        transaction.Commit();

                        // Eğer etkilenen satır sayısı 1 ise silme başarılı olmuştur
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata durumunda işlemleri geri al (rollback)
                    transaction?.Rollback();
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }



        public DataTable GetUsers() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT userID, username, firstName, lastName FROM users ORDER BY firstName ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable users = new DataTable();
                adapter.Fill(users);
                return users;
            }
        }

        public DataTable GetDetailUser(int userID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    string query = "SELECT username, userPassword, isAdmin, FirstName, LastName, Email, Title, phoneNumber, position FROM users WHERE userID = @userID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@userID", userID);
                    DataTable users = new DataTable();
                    adapter.Fill(users);

                    return users; // Return the DataTable even if it's empty
                } catch (Exception ex) {
                    MessageBox.Show($"Error: {ex.Message}");
                    return null; // Handle exceptions and ensure the method returns a value
                }
            }
        }


        public DataTable GetAcademics() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    string query = "SELECT AcademicID, FirstName, LastName, keyWords FROM Academics ORDER BY FirstName ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable academics = new DataTable();
                    adapter.Fill(academics);
                    return academics;
                } catch (Exception ex) {
                    MessageBox.Show($"Error: {ex.Message}");
                    return null;
                }
            }
        }
        public DataTable GetDetailsAcademics(int academicID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    string query = "SELECT FirstName, LastName, Email, Phone, Title, Position, keyWords, tcID FROM Academics WHERE AcademicID = @AcademicID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@AcademicID", academicID);
                    DataTable academics = new DataTable();
                    adapter.Fill(academics);

                    return academics; // Return the DataTable even if it's empty
                } catch (Exception ex) {
                    MessageBox.Show($"Error: {ex.Message}");
                    return null; // Handle exceptions and ensure the method returns a value
                }
            }
        }


        //Employees
        public DataTable GetEmployees(int companyId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS FullName FROM Employees WHERE CompanyID = @CompanyID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@CompanyID", companyId);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }


        public DataTable GetListEmployees() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS FullName FROM Employees ORDER BY Fullname ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }

        public DataTable GetDetailsEmployee(int EmployeeID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT FirstName, LastName, Email, Phone, Title, Position, CompanyID, EmployeeTcID FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }



        public int AddMeeting(Meeting meeting) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "INSERT INTO Meetings (MeetingDate, MeetingTime, MeetingTitle, MeetingNotes, MeetingLocation, MeetingType, isImportant) OUTPUT INSERTED.MeetingID VALUES (@Date, @Time, @Title, @Notes, @Location, @MeetingType, @isImportant)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", meeting.Date);
                cmd.Parameters.AddWithValue("@Time", meeting.Time);
                cmd.Parameters.AddWithValue("@Title", meeting.Title);
                cmd.Parameters.AddWithValue("@Notes", meeting.Notes);
                cmd.Parameters.AddWithValue("@Location", meeting.Location);
                cmd.Parameters.AddWithValue("@MeetingType", meeting.MeetingType);
                cmd.Parameters.AddWithValue("@isImportant", meeting.isImportant);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public void UpdateMeeting(Meeting meeting) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "UPDATE Meetings SET MeetingDate = @Date, MeetingTime = @Time, MeetingTitle = @Title, MeetingNotes = @Notes, MeetingLocation = @Location, MeetingType = @MeetingType, isImportant = @isImportant WHERE MeetingID = @MeetingID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", meeting.Date);
                cmd.Parameters.AddWithValue("@Time", meeting.Time);
                cmd.Parameters.AddWithValue("@Title", meeting.Title);
                cmd.Parameters.AddWithValue("@Notes", meeting.Notes);
                cmd.Parameters.AddWithValue("@Location", meeting.Location);
                cmd.Parameters.AddWithValue("@MeetingType", meeting.MeetingType);
                cmd.Parameters.AddWithValue("@isImportant", meeting.isImportant);
                cmd.Parameters.AddWithValue("@MeetingID", meeting.MeetingID); // Güncellenecek toplantının ID'si
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool DeleteMeeting(int meetingId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                SqlTransaction transaction = null;

                try {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // 1. Adım: MeetingParticipants tablosundan ilgili MeetingID'ye ait tüm katılımcıları sil
                    string query1 = "DELETE FROM MeetingParticipants WHERE MeetingID = @MeetingID";
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn, transaction)) {
                        cmd1.Parameters.AddWithValue("@MeetingID", meetingId);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2. Adım: MeetingDocuments tablosundan toplantıya ait tüm belgeleri sil
                    string query2 = "DELETE FROM MeetingDocuments WHERE MeetingID = @MeetingID";
                    using (SqlCommand cmd2 = new SqlCommand(query2, conn, transaction)) {
                        cmd2.Parameters.AddWithValue("@MeetingID", meetingId);
                        cmd2.ExecuteNonQuery();
                    }

                    // 3. Adım: Meetings tablosundan toplantıyı sil
                    string query3 = "DELETE FROM Meetings WHERE MeetingID = @MeetingID";
                    using (SqlCommand cmd3 = new SqlCommand(query3, conn, transaction)) {
                        cmd3.Parameters.AddWithValue("@MeetingID", meetingId);
                        int result = cmd3.ExecuteNonQuery();

                        // İşlemleri commit et
                        transaction.Commit();

                        // Eğer etkilenen satır sayısı 1 ise silme başarılı olmuştur
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata durumunda işlemleri geri al (rollback)
                    transaction?.Rollback();
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }




        public void AddMeetingParticipant(int meetingId, string participantType, int participantId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "INSERT INTO MeetingParticipants (MeetingID, ParticipantType, ParticipantID) VALUES (@MeetingID, @ParticipantType, @ParticipantID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MeetingID", meetingId);
                cmd.Parameters.AddWithValue("@ParticipantType", participantType);
                cmd.Parameters.AddWithValue("@ParticipantID", participantId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMeetingParticipants(int meetingId,
                                        ListBox lbSelectedCompanies,
                                        ListBox lbSelectedEmployees,
                                        ListBox lbSelectedAcademics,
                                        ListBox lbSelectedUsers) {
            // Yeni katılımcıların ID'lerini ve türlerini saklayacak bir Dictionary oluşturuyoruz
            var newParticipants = new List<(int ID, string Type)>();

            // Katılımcı listelerini oluştur ve ListBox'ın adından Type bilgisini belirle
            AddParticipantsFromListBox(lbSelectedCompanies, newParticipants, "Company");
            AddParticipantsFromListBox(lbSelectedEmployees, newParticipants, "Employee");
            AddParticipantsFromListBox(lbSelectedAcademics, newParticipants, "Academic");
            AddParticipantsFromListBox(lbSelectedUsers, newParticipants, "User");

            // Veritabanında mevcut katılımcıları silme
            string queryDeleteAllParticipants = @"
DELETE FROM MeetingParticipants
WHERE MeetingID = @MeetingID";

            // Veritabanına yeni katılımcıları ekleme
            string queryAddParticipant = @"
INSERT INTO MeetingParticipants (MeetingID, ParticipantType, ParticipantID)
VALUES (@MeetingID, @ParticipantType, @ParticipantID)";

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                // Mevcut katılımcıları silme
                using (SqlCommand deleteCmd = new SqlCommand(queryDeleteAllParticipants, conn)) {
                    deleteCmd.Parameters.AddWithValue("@MeetingID", meetingId);
                    deleteCmd.ExecuteNonQuery();
                }

                // Yeni katılımcıları ekleme
                foreach (var participant in newParticipants) {
                    using (SqlCommand addCmd = new SqlCommand(queryAddParticipant, conn)) {
                        addCmd.Parameters.AddWithValue("@MeetingID", meetingId);
                        addCmd.Parameters.AddWithValue("@ParticipantType", participant.Type);
                        addCmd.Parameters.AddWithValue("@ParticipantID", participant.ID);
                        addCmd.ExecuteNonQuery();
                    }
                }
            }

            // ListBox'ları güncelle
            LoadParticipants(meetingId, lbSelectedCompanies, lbSelectedEmployees, lbSelectedAcademics, lbSelectedUsers);
        }

        private void AddParticipantsFromListBox(ListBox listBox, List<(int ID, string Type)> participants, string type) {
            foreach (var item in listBox.Items) {
                // Katılımcı ID'sini ve adını temsil eden nesneyi elde et
                // `item` nesnesinin `Participant` türünde olduğunu varsayıyoruz
                var participant = item as Participant;
                if (participant != null) {
                    // Katılımcı ID'sini ve türünü ekle
                    participants.Add((participant.ID, type));
                }
            }
        }

        // Belge ekleme işlemi
        public void AddMeetingDocuments(int meetingId, List<byte[]> documentDataList, List<string> fileNames, List<string> documentTypes) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                for (int i = 0; i < documentDataList.Count; i++) {
                    byte[] documentData = documentDataList[i];
                    string fileName = fileNames[i];
                    string documentType = documentTypes[i];

                    string insertQuery = "INSERT INTO MeetingDocuments (MeetingID, DocumentType, DocumentData, FileName) VALUES (@MeetingID, @DocumentType, @DocumentData, @FileName)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn)) {
                        insertCmd.Parameters.AddWithValue("@MeetingID", meetingId);
                        insertCmd.Parameters.AddWithValue("@DocumentType", documentType);
                        insertCmd.Parameters.AddWithValue("@DocumentData", documentData);
                        insertCmd.Parameters.AddWithValue("@FileName", fileName);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }



        public void UpdateMeetingDocuments(int meetingId, List<byte[]> newDocumentDataList, List<string> fileNames, List<string> documentTypes) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                // Mevcut belge sayısını kontrol et
                int existingDocumentCount = GetDocumentCountForMeeting(meetingId); // Mevcut belge sayısını al

                if (existingDocumentCount < 3) {
                    int remainingCapacity = 3 - existingDocumentCount;
                    int documentsToAdd = Math.Min(newDocumentDataList.Count, remainingCapacity);

                    for (int i = 0; i < documentsToAdd; i++) {
                        byte[] documentData = newDocumentDataList[i];
                        string fileName = fileNames[i];
                        string documentType = documentTypes[i];

                        string insertQuery = "INSERT INTO MeetingDocuments (MeetingID, DocumentType, DocumentData, FileName) VALUES (@MeetingID, @DocumentType, @DocumentData, @FileName)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn)) {
                            insertCmd.Parameters.AddWithValue("@MeetingID", meetingId);
                            insertCmd.Parameters.AddWithValue("@DocumentType", documentType);
                            insertCmd.Parameters.AddWithValue("@DocumentData", documentData);
                            insertCmd.Parameters.AddWithValue("@FileName", fileName);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                } else {
                    MessageBox.Show("Toplamda 3 dosyadan fazlası eklenemez.");
                }
            }
        }



        public void DeleteMeetingDocuments(int meetingId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                string deleteQuery = "DELETE FROM MeetingDocuments WHERE MeetingID = @MeetingID";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn)) {
                    deleteCmd.Parameters.AddWithValue("@MeetingID", meetingId);
                    deleteCmd.ExecuteNonQuery();
                }
            }
        }

        public int GetDocumentCountForMeeting(int meetingId) {
            int currentDocumentCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                string query = "SELECT COUNT(*) FROM MeetingDocuments WHERE MeetingID = @MeetingID";
                using (SqlCommand command = new SqlCommand(query, conn)) {
                    command.Parameters.AddWithValue("@MeetingID", meetingId);
                    currentDocumentCount = (int)command.ExecuteScalar();
                }
            }

            return currentDocumentCount;
        }


        public void ViewDocuments(int meetingId) {
            ViewDocumentsForm viewDocumentsForm = new ViewDocumentsForm(meetingId, connectionString);
            viewDocumentsForm.ShowDialog();
        }


        // Veritabanından MeetingID'ye göre çoklu dokümanları alır

        public DataTable GetMeetingDetails(int meetingId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT MeetingID, MeetingTitle, MeetingNotes, MeetingDate, MeetingTime, MeetingLocation FROM Meetings WHERE MeetingID = @MeetingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MeetingID", meetingId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable meetingDetails = new DataTable();
                adapter.Fill(meetingDetails);

                return meetingDetails;
            }
        }
        public DataTable GetAllMeetings() {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                // Sorguyu güncelle: MeetingDate'e göre sıralama yap
                string query = "SELECT MeetingID, MeetingTitle, MeetingDate FROM Meetings ORDER BY MeetingDate DESC";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable meetings = new DataTable();
                adapter.Fill(meetings);

                return meetings;
            }
        }

        public void LoadAllMeetingTitles(ListBox listBox) {
            // Tüm toplantıları al
            DataTable allMeetings = GetAllMeetings();

            // ListBox içindeki mevcut öğeleri temizle
            listBox.Items.Clear();

            // DataTable'daki her bir satır için döngü
            foreach (DataRow row in allMeetings.Rows) {
                // MeetingTitle değerini ListBox'a ekle
                listBox.Items.Add(row["MeetingTitle"].ToString());
            }
        }
        public DataRow GetMeetingById(int meetingID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT * FROM Meetings WHERE MeetingID = @MeetingID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MeetingID", meetingID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable meetingTable = new DataTable();
                adapter.Fill(meetingTable);

                if (meetingTable.Rows.Count > 0) {
                    return meetingTable.Rows[0]; // Tek bir satır döner
                } else {
                    return null; // Hiçbir sonuç dönmezse
                }
            }
        }


        public DataTable ExecuteQuery(string query) {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                            adapter.Fill(dt);
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Veritabanı sorgu hatası: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable GetMeetingParticipants(int meetingId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"
            SELECT mp.ParticipantType, 
                   CASE 
                       WHEN mp.ParticipantType = 'Company' THEN ISNULL(c.Name, '')
                       ELSE ''
                   END AS CompanyName, 
                   CASE 
                       WHEN mp.ParticipantType = 'Company' THEN ISNULL(c.FieldsOfActivity, '')
                       ELSE ''
                   END AS CompanyFieldsOfActivity, 
                   CASE 
                       WHEN mp.ParticipantType = 'Employee' THEN ISNULL(e.FirstName + ' ' + e.LastName, '')
                       WHEN mp.ParticipantType = 'Academic' THEN ISNULL(a.FirstName + ' ' + a.LastName, '')
                       WHEN mp.ParticipantType = 'User' THEN ISNULL(u.FirstName + ' ' + u.LastName, '')
                       ELSE ''
                   END AS UserName,
                   CASE 
                       WHEN mp.ParticipantType = 'Employee' THEN ISNULL(e.Title, '')
                       WHEN mp.ParticipantType = 'Academic' THEN ISNULL(a.Title, '')
                       WHEN mp.ParticipantType = 'User' THEN ISNULL(u.Title, '')
                       ELSE '' 
                   END AS UserTitle, 
                   CASE 
                       WHEN mp.ParticipantType = 'Employee' THEN ISNULL(e.Phone, '')
                       WHEN mp.ParticipantType = 'Academic' THEN ISNULL(a.Phone, '')
                       WHEN mp.ParticipantType = 'User' THEN ISNULL(u.PhoneNumber, '')
                       ELSE '' 
                   END AS UserPhone,
                   CASE 
                       WHEN mp.ParticipantType = 'Employee' THEN ISNULL(e.Email, '')
                       WHEN mp.ParticipantType = 'Academic' THEN ISNULL(a.Email, '')
                       WHEN mp.ParticipantType = 'User' THEN ISNULL(u.email, '')
                       ELSE '' 
                   END AS Email,
                   CASE 
                       WHEN mp.ParticipantType = 'Employee' THEN ISNULL(g.Name, '')
                       WHEN mp.ParticipantType = 'User' THEN ISNULL(u.CompanyName, '')
                       ELSE '' 
                   END AS EmployeeCompany
            FROM MeetingParticipants mp
            LEFT JOIN Companies c ON mp.ParticipantType = 'Company' AND mp.ParticipantID = c.CompanyID
            LEFT JOIN Employees e ON mp.ParticipantType = 'Employee' AND mp.ParticipantID = e.EmployeeID
            LEFT JOIN Academics a ON mp.ParticipantType = 'Academic' AND mp.ParticipantID = a.AcademicID
            LEFT JOIN Users u ON mp.ParticipantType = 'User' AND mp.ParticipantID = u.UserID
            LEFT JOIN Companies g ON mp.ParticipantType = 'Employee' AND e.CompanyID = g.CompanyID
            WHERE mp.MeetingID = @MeetingID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MeetingID", meetingId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable participants = new DataTable();
                adapter.Fill(participants);

                return participants;
            }
        }
        public void LoadParticipants(int meetingId,
                               ListBox lbSelectedCompanies,
                               ListBox lbSelectedEmployees,
                               ListBox lbSelectedAcademics,
                               ListBox lbSelectedUsers) {
            string query = @"
        SELECT 
            mp.ParticipantType,
            mp.ParticipantID,
            CASE 
                WHEN mp.ParticipantType = 'Company' THEN c.Name
                WHEN mp.ParticipantType = 'Employee' THEN e.FirstName + ' ' + e.LastName
                WHEN mp.ParticipantType = 'Academic' THEN a.FirstName + ' ' + a.LastName
                WHEN mp.ParticipantType = 'User' THEN u.FirstName + ' ' + u.LastName
                ELSE ''
            END AS DisplayName
        FROM MeetingParticipants mp
        LEFT JOIN Companies c ON mp.ParticipantID = c.CompanyID AND mp.ParticipantType = 'Company'
        LEFT JOIN Employees e ON mp.ParticipantID = e.EmployeeID AND mp.ParticipantType = 'Employee'
        LEFT JOIN Academics a ON mp.ParticipantID = a.AcademicID AND mp.ParticipantType = 'Academic'
        LEFT JOIN Users u ON mp.ParticipantID = u.UserID AND mp.ParticipantType = 'User'
        WHERE mp.MeetingID = @MeetingID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MeetingID", meetingId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    // ListBox'ları temizle
                    lbSelectedCompanies.Items.Clear();
                    lbSelectedEmployees.Items.Clear();
                    lbSelectedAcademics.Items.Clear();
                    lbSelectedUsers.Items.Clear();

                    while (reader.Read()) {
                        string participantType = reader["ParticipantType"].ToString();
                        int participantID = Convert.ToInt32(reader["ParticipantID"]);
                        string displayName = reader["DisplayName"].ToString();

                        // Participant nesnesi oluşturma
                        Participant participant = new Participant(participantID, displayName);

                        // Katılımcı türüne göre doğru ListBox'a ekle
                        switch (participantType) {
                            case "Company":
                                lbSelectedCompanies.Items.Add(participant);
                                break;

                            case "Employee":
                                lbSelectedEmployees.Items.Add(participant);
                                break;

                            case "Academic":
                                lbSelectedAcademics.Items.Add(participant);
                                break;

                            case "User":
                                lbSelectedUsers.Items.Add(participant);
                                break;
                        }
                    }
                }
            }
        }


        public void LoadParticipants(int meetingId, ListBox listofParticipants) {
            // SQL sorgusu, katılımcıların tipine göre adlarını ve bilgilerini almak için
            string query = @"
        SELECT 
            mp.ParticipantType,
            mp.ParticipantID,
            CASE 
                WHEN mp.ParticipantType = 'Company' THEN c.Name
                WHEN mp.ParticipantType = 'Employee' THEN e.FirstName + ' ' + e.LastName
                WHEN mp.ParticipantType = 'Academic' THEN a.FirstName + ' ' + a.LastName
                WHEN mp.ParticipantType = 'User' THEN u.FirstName + ' ' + u.LastName
                ELSE ''
            END AS DisplayName,
            mp.ParticipantType AS Type
        FROM MeetingParticipants mp
        LEFT JOIN Companies c ON mp.ParticipantID = c.CompanyID AND mp.ParticipantType = 'Company'
        LEFT JOIN Employees e ON mp.ParticipantID = e.EmployeeID AND mp.ParticipantType = 'Employee'
        LEFT JOIN Academics a ON mp.ParticipantID = a.AcademicID AND mp.ParticipantType = 'Academic'
        LEFT JOIN Users u ON mp.ParticipantID = u.UserID AND mp.ParticipantType = 'User'
        WHERE mp.MeetingID = @MeetingID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MeetingID", meetingId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) {
                    List<Participants> participantsList = new List<Participants>();

                    while (reader.Read()) {
                        Participants participant = new Participants {
                            DisplayName = reader["DisplayName"].ToString(),
                            ID = Convert.ToInt32(reader["ParticipantID"]),
                            Type = reader["Type"].ToString()
                        };

                        participantsList.Add(participant);
                    }

                    // ListBox'ı doldur
                    listofParticipants.DataSource = participantsList;
                    listofParticipants.DisplayMember = "DisplayName";
                    listofParticipants.ValueMember = "ID";
                }
            }
        }






        public DataTable GetParticipantDetailsById(int participantId, string participantType) {
            string query;
            switch (participantType) {
                case "Company":
                    query = "SELECT * FROM Companies WHERE CompanyID = @ParticipantID";
                    break;
                case "Employee":
                    query = "SELECT * FROM Employees WHERE EmployeeID = @ParticipantID";
                    break;
                case "Academic":
                    query = "SELECT * FROM Academics WHERE AcademicID = @ParticipantID";
                    break;
                case "User":
                    query = "SELECT * FROM Users WHERE UserID = @ParticipantID";
                    break;
                default:
                    throw new ArgumentException("Bilinmeyen katılımcı türü.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParticipantID", participantId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable participantDetails = new DataTable();
                adapter.Fill(participantDetails);

                return participantDetails;
            }
        }

        public int CountofMeetings(string participantType, int participantID) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT COUNT(*) AS sumMeeting FROM MeetingParticipants WHERE ParticipantType = @participantType AND ParticipantID = @participantID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@participantType", participantType);
                command.Parameters.AddWithValue("@participantID", participantID);

                connection.Open();

                // Execute the query and retrieve the result
                int sumMeeting = (int)command.ExecuteScalar();

                return sumMeeting;
            }
        }

        // Katılımcı ID ve türüne göre toplantıları sorgulama yapacak metot

        public List<Participants> GetAllData() {
            List<Participants> allData = new List<Participants>();

            // Companies tablosundaki verileri al
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                string query = "SELECT CompanyID, Name, 'Company' AS Type FROM Companies";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            allData.Add(new Participants {
                                ID = Convert.ToInt32(reader["CompanyID"]),
                                DisplayName = reader["Name"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }
                    }
                }
            }

            // Employees tablosundaki verileri al
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                string query = "SELECT EmployeeID, FirstName + ' ' + LastName AS DisplayName, 'Employee' AS Type FROM Employees";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            allData.Add(new Participants {
                                ID = Convert.ToInt32(reader["EmployeeID"]),
                                DisplayName = reader["DisplayName"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }
                    }
                }
            }

            // Users tablosundaki verileri al
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                string query = "SELECT userID, FirstName + ' ' + LastName AS DisplayName, 'User' AS Type FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            allData.Add(new Participants {
                                ID = Convert.ToInt32(reader["userID"]),
                                DisplayName = reader["DisplayName"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }
                    }
                }
            }

            // Academics tablosundaki verileri al
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                string query = "SELECT AcademicID, FirstName + ' ' + LastName AS DisplayName, 'Academic' AS Type FROM Academics";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            allData.Add(new Participants {
                                ID = Convert.ToInt32(reader["AcademicID"]),
                                DisplayName = reader["DisplayName"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }
                    }
                }
            }

            return allData.OrderBy(p => p.DisplayName).ToList();
        }

        public DataTable GetMeetingsByParticipantsAndDateRange(
            List<int> participantIds,
            List<string> participantTypes,
            DateTime startDate,
            DateTime endDate) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                // Katılımcı ID'leri ve türleri için listeyi parametre olarak hazırlama
                string idParams = string.Join(",", participantIds);
                string typeParams = string.Join(",", participantTypes.Select(t => $"'{t}'"));

                // Tarih aralığını kontrol eden sorgu
                string query = $@"
                SELECT DISTINCT M.MeetingID, M.MeetingTitle, M.MeetingDate
                FROM Meetings M
                INNER JOIN MeetingParticipants MP ON M.MeetingID = MP.MeetingID
                WHERE MP.ParticipantID IN ({idParams})
                AND MP.ParticipantType IN ({typeParams})
                AND M.MeetingDate BETWEEN @StartDate AND @EndDate
                ORDER BY M.MeetingDate DESC";

                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekle
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable meetings = new DataTable();
                adapter.Fill(meetings);

                return meetings;
            }
        }


        public List<Meeting> GetMeetingsWithSelectedParticipantsAndDateRange(
    int? companyId, int? userId, int? academicId, int? employeeId,
    DateTime? dateTimeStart, DateTime? dateTimeEnd, string meetingType, bool isImportant) {
            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();

                var query = new StringBuilder();
                query.AppendLine("SELECT DISTINCT m.MeetingID, m.MeetingTitle, m.MeetingDate, m.MeetingType, m.isImportant");
                query.AppendLine("FROM Meetings m");
                query.AppendLine("LEFT JOIN MeetingParticipants mp ON m.MeetingID = mp.MeetingID");

                // WHERE clause'u dinamik hale getirmek için koşulları listeye ekleyeceğiz
                var whereClauses = new List<string>();

                // Parametrelere göre filtreleri ekle
                if (companyId.HasValue) {
                    whereClauses.Add("mp.ParticipantType = 'Company' AND mp.ParticipantID = @CompanyId");
                }
                if (userId.HasValue) {
                    whereClauses.Add("mp.ParticipantType = 'User' AND mp.ParticipantID = @UserId");
                }
                if (academicId.HasValue) {
                    whereClauses.Add("mp.ParticipantType = 'Academic' AND mp.ParticipantID = @AcademicId");
                }
                if (employeeId.HasValue) {
                    whereClauses.Add("mp.ParticipantType = 'Employee' AND mp.ParticipantID = @EmployeeId");
                }

                // Tarih aralığı kontrolü
                if (dateTimeStart.HasValue) {
                    whereClauses.Add("m.MeetingDate >= @StartDate");
                }
                if (dateTimeEnd.HasValue) {
                    whereClauses.Add("m.MeetingDate <= @EndDate");
                }

                // Eğer meetingType null değilse
                if (!string.IsNullOrEmpty(meetingType)) {
                    whereClauses.Add("m.MeetingType = @MeetingType");
                }

                // isImportant kontrolü
                whereClauses.Add("m.isImportant = @isImportant");

                // Eğer WHERE koşulları varsa, bunları sorguya ekle
                if (whereClauses.Any()) {
                    query.AppendLine("WHERE " + string.Join(" AND ", whereClauses));
                }

                // Toplantı tarihine göre sıralama
                query.AppendLine("ORDER BY m.MeetingDate DESC");

                using (var command = new SqlCommand(query.ToString(), connection)) {
                    // Parametreleri ekle
                    if (companyId.HasValue) {
                        command.Parameters.AddWithValue("@CompanyId", companyId.Value);
                    }
                    if (userId.HasValue) {
                        command.Parameters.AddWithValue("@UserId", userId.Value);
                    }
                    if (academicId.HasValue) {
                        command.Parameters.AddWithValue("@AcademicId", academicId.Value);
                    }
                    if (employeeId.HasValue) {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId.Value);
                    }

                    // Tarih aralığı için parametreleri ekle
                    if (dateTimeStart.HasValue) {
                        command.Parameters.AddWithValue("@StartDate", dateTimeStart.Value);
                    }
                    if (dateTimeEnd.HasValue) {
                        command.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value);
                    }

                    // MeetingType ve isImportant parametreleri
                    if (!string.IsNullOrEmpty(meetingType)) {
                        command.Parameters.AddWithValue("@MeetingType", meetingType);
                    }
                    command.Parameters.AddWithValue("@isImportant", isImportant);

                    var meetings = new List<Meeting>();

                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var meeting = new Meeting {
                                MeetingID = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Date = reader.GetDateTime(2),
                                MeetingType = !reader.IsDBNull(3) ? reader.GetString(3) : "Bilinmiyor",
                                isImportant = reader.GetBoolean(4)
                            };
                            meetings.Add(meeting);
                        }
                    }

                    return meetings;
                }
            }
        }


        //Statistic

        public List<ParticipantMeetingData> GetParticipantMeetingDataForUsers(DateTime startDate, DateTime endDate) {
            var data = new List<ParticipantMeetingData>();

            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    string query = @"
            SELECT
                mp.ParticipantID,
                u.FirstName + ' ' + u.LastName AS FullName,
                'User' AS ParticipantType,
                COUNT(mp.MeetingID) AS MeetingCount
            FROM
                MeetingParticipants mp
            INNER JOIN
                users u ON mp.ParticipantID = u.UserID
            INNER JOIN
                Meetings m ON mp.MeetingID = m.MeetingID
            WHERE
                mp.ParticipantType = 'user'
                AND m.MeetingDate BETWEEN @StartDate AND @EndDate
            GROUP BY
                mp.ParticipantID, u.FirstName, u.LastName
            ORDER BY
                MeetingCount DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        var participantData = new ParticipantMeetingData {
                            FullName = reader["FullName"].ToString(),
                            ParticipantID = reader["ParticipantID"].ToString(),
                            ParticipantType = reader["ParticipantType"].ToString(),
                            MeetingCount = Convert.ToInt32(reader["MeetingCount"])
                        };

                        data.Add(participantData);
                    }
                }
            } catch (Exception ex) {
                throw new Exception("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
            return data;
        }

        public int GetTotalMeetingCount(DateTime startDate, DateTime endDate) {
            int totalMeetings = 0;

            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    // Tarih aralığına göre toplantı sayısını hesaplayan sorgu
                    string query = @"
                SELECT COUNT(*)
                FROM Meetings
                WHERE MeetingDate >= @StartDate AND MeetingDate <= @EndDate";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();

                    // Toplam toplantı sayısını al
                    totalMeetings = (int)command.ExecuteScalar();
                }
            } catch (Exception ex) {
                throw new Exception("Toplam toplantı sayısı alınırken bir hata oluştu: " + ex.Message);
            }

            return totalMeetings;
        }

        public DataTable GetMeetingDataForHeatMap(DateTime startDate, DateTime endDate) {
            DataTable dt = new DataTable();

            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    // SQL sorgusu
                    string query = @"
                SELECT 
                    DATEPART(WEEKDAY, MeetingDate) AS WeekDay,
                    DATEPART(HOUR, MeetingTime) AS Hour,
                    COUNT(*) AS MeetingCount
                FROM 
                    Meetings
                WHERE 
                    MeetingDate >= @StartDate AND MeetingDate <= @EndDate
                GROUP BY 
                    DATEPART(WEEKDAY, MeetingDate),
                    DATEPART(HOUR, MeetingTime)
                ORDER BY 
                    DATEPART(WEEKDAY, MeetingDate),
                    DATEPART(HOUR, MeetingTime)";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        // Veri adaptörü ile verileri al
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            } catch (Exception ex) {
                // Hata ile ilgili bilgi ver
                throw new Exception("Veri alınırken bir hata oluştu: " + ex.Message);
            }

            return dt;
        }

        public void CastingName(TextBox textBox) {
            // Textbox'taki metni al
            string input = textBox.Text;

            // Kelimeleri ayır
            string[] words = input.Split(' ');

            // Her kelimenin ilk harfini büyük, geri kalanını küçük yap
            for (int i = 0; i < words.Length; i++) {
                if (words[i].Length > 0) {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            // Düzenlenmiş kelimeleri birleştir
            textBox.Text = string.Join(" ", words);

            // İmleci sonuna getir
            textBox.SelectionStart = textBox.Text.Length;
        }

        public DataTable LoadEventsForWeek(DateTime startOfWeek, DateTime endOfWeek) {
            DataTable eventsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"
                    SELECT MeetingID, MeetingTitle, MeetingDate, MeetingType, isImportant
                    FROM Meetings
                    WHERE MeetingDate BETWEEN @StartOfWeek AND @EndOfWeek
                    ORDER BY MeetingDate";

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@StartOfWeek", startOfWeek);
                    command.Parameters.AddWithValue("@EndOfWeek", endOfWeek);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(eventsTable);
                }
            }

            return eventsTable;
        }


        public string GetEmailFromId(int id, string type) {
            string email = null;
            string query = "";
            SqlParameter[] parameters = new SqlParameter[1];

            // `type` parametresine göre sorgu oluştur
            switch (type) {
                case "Companies":
                    query = "SELECT Email FROM Companies WHERE CompanyID = @ID";
                    parameters[0] = new SqlParameter("@ID", id);
                    break;
                case "Employees":
                    query = "SELECT Email FROM Employees WHERE EmployeeID = @ID";
                    parameters[0] = new SqlParameter("@ID", id);
                    break;
                case "Academics":
                    query = "SELECT Email FROM Academics WHERE AcademicID = @ID";
                    parameters[0] = new SqlParameter("@ID", id);
                    break;
                case "Users":
                    query = "SELECT Email FROM Users WHERE UserID = @ID";
                    parameters[0] = new SqlParameter("@ID", id);
                    break;
                default:
                    throw new ArgumentException("Invalid type specified.");
            }

            // Veritabanı bağlantısını oluştur ve sorguyu çalıştır
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddRange(parameters);

                try {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null) {
                        email = result.ToString();
                    }
                } catch (Exception ex) {
                    // Hata yönetimi
                    MessageBox.Show("E-posta adresi alınırken bir hata oluştu: " + ex.Message);
                }
            }

            return email;
        }

        // SQL sorgusu çalıştırıp sonuçları dönen metot
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null) {
            DataTable dt = new DataTable();

            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        if (parameters != null) {
                            cmd.Parameters.AddRange(parameters); // Parametreleri ekle
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt); // Sonuçları DataTable'a doldur
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }

            return dt;
        }

        // Parametreli SQL sorgusu çalıştıran metot
        public void ExecuteNonQuery(string query, SqlParameter[] parameters = null) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        if (parameters != null) {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }


        // Log eklemek için bir metot
        public void AddLog(string logType, string logDescription) {
            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    conn.Open();
                    string query = "INSERT INTO Logs (LogType, LogDescription) VALUES (@LogType, @LogDescription)";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@LogType", logType);
                        cmd.Parameters.AddWithValue("@LogDescription", logDescription);

                        cmd.ExecuteNonQuery(); // Veriyi veritabanına ekler
                    }
                }
            } catch (Exception ex) {
                // Hata mesajı gösterebiliriz
                MessageBox.Show("Veri ekleme hatası: " + ex.Message);
            }
        }

        public void CheckUpcomingMeetingsForNextWeek(int currentUserId) {
            // Tarihleri hesapla
            var (startOfNextWeek, endOfNextWeek) = GetNextWeekDateRange();

            // SQL sorgusu
                    var query = @"
                SELECT m.MeetingTitle, m.MeetingDate, m.MeetingTime
                FROM Meetings m
                JOIN MeetingParticipants mp ON m.MeetingID = mp.MeetingID
                WHERE m.MeetingDate BETWEEN @StartDate AND @EndDate
                  AND mp.ParticipantID = @UserId
                  AND mp.ParticipantType = 'User'
                ORDER BY m.MeetingDate, m.MeetingTime";

            // Veritabanı işlemleri
            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (var command = new SqlCommand(query, connection)) {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@StartDate", startOfNextWeek);
                    command.Parameters.AddWithValue("@EndDate", endOfNextWeek);
                    command.Parameters.AddWithValue("@UserId", currentUserId);

                    var meetings = GetMeetings(command);

                    if (meetings.Any()) {
                        ShowMeetingSummary(meetings);
                    } else {
                        ShowNoMeetingsMessage();
                    }
                }
            }
        }

        private (DateTime startOfNextWeek, DateTime endOfNextWeek) GetNextWeekDateRange() {
            var today = DateTime.Today;
            var startOfNextWeek = today.AddDays(7 - (int)today.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfNextWeek = startOfNextWeek.AddDays(7).AddTicks(-1);
            return (startOfNextWeek, endOfNextWeek);
        }

        private List<(string Title, DateTime Date, TimeSpan Time)> GetMeetings(SqlCommand command) {
            var meetings = new List<(string Title, DateTime Date, TimeSpan Time)>();

            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    var title = reader.GetString(0);
                    var date = reader.GetDateTime(1);
                    var time = reader.GetTimeSpan(2);

                    meetings.Add((title, date, time));
                }
            }

            return meetings;
        }

        public DateTime GetMeetingDateByID(int meetingID) {
            string query = "SELECT MeetingDate FROM Meetings WHERE MeetingID = @MeetingID";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MeetingID", meetingID);

                connection.Open();
                DateTime meetingDate = (DateTime)cmd.ExecuteScalar();
                connection.Close();

                return meetingDate;
            }
        }

        private void ShowMeetingSummary(IEnumerable<(string Title, DateTime Date, TimeSpan Time)> meetings) {
            var messageBuilder = new StringBuilder();

            foreach (var meeting in meetings) {
                var formattedTime = meeting.Time.ToString(@"hh\:mm");
                messageBuilder.AppendLine($"- {meeting.Date:dd.MM.yyyy} tarihinde {formattedTime} saatinde '{meeting.Title}'");
            }

            var message = $"Önümüzdeki hafta Faaliyetleriniz şunlar:\n{messageBuilder.ToString()}";

            MessageBox.Show(message, "Faaliyet Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowNoMeetingsMessage() {
            MessageBox.Show("Önümüzdeki hafta için herhangi bir faaliyetiniz bulunmamaktadır.",
                            "Bilgi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public DataTable SearchAcademicsAndCompanies(string searchTerm) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                string query = @"
                SELECT 'Academic' AS Tip, AcademicID AS ID, FirstName + ' ' + LastName AS İsim, Keywords AS Alanlar
                FROM Academics
                WHERE FirstName LIKE @SearchTerm OR LastName LIKE @SearchTerm OR Keywords LIKE @SearchTerm
                UNION
                SELECT 'Company' AS Tip, CompanyID AS ID, name AS İsim, FieldsOfActivity AS Alanlar
                FROM Companies
                WHERE name LIKE @SearchTerm OR FieldsOfActivity LIKE @SearchTerm";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable results = new DataTable();
                    adapter.Fill(results);
                    return results;
                }
            }
        }

        // Envanter öğelerini getir
        /*public DataTable GetInventoryItems() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT itemID, itemName, itemType, userID, status,  brand, model, location, department  FROM inventory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable inventoryTable = new DataTable();
                adapter.Fill(inventoryTable);
                return inventoryTable;
            }
        }*/

        public DataTable GetInventoryItems() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                // FirstName ve LastName kolonlarını birleştirerek FullName oluşturuyoruz
                string query = @"
            SELECT 
                i.itemID, 
                i.itemName, 
                i.itemType, 
                i.userID, 
                (u.FirstName + ' ' + u.LastName) AS FullName, -- FirstName ve LastName birleştiriliyor
                i.status, 
                i.brand, 
                i.model, 
                i.location, 
                i.department
            FROM inventory i
            LEFT JOIN users u ON i.userID = u.userID"; // Kullanıcıyı LEFT JOIN ile ekliyoruz

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable inventoryTable = new DataTable();
                adapter.Fill(inventoryTable);
                return inventoryTable;
            }
        }

        public DataRow GetInventoryDetails(int itemID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"SELECT itemID, itemName, itemType, serialNumber, brand, model, purchaseDate, 
                                warrantyEndDate, cost, taxRate, photo, location, department, 
                                userID, status, lastMaintenanceDate, notes ,reminderStatus
                         FROM inventory 
                         WHERE itemID = @itemID";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Gelen int değerine 'TTO' ekleyerek parametreyi ayarla
                string formattedItemID = "TTO" + itemID.ToString();
                cmd.Parameters.AddWithValue("@itemID", formattedItemID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);

                if (resultTable.Rows.Count > 0)
                    return resultTable.Rows[0];
                else
                    return null;
            }
        }


        public DataTable GetInventoryItemsByUserId(int userId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                // Sorgu userId'ye göre filtreler
                string query = @"
        SELECT 
            i.itemID, 
            i.itemName, 
            i.itemType, 
            i.userID, 
            (u.FirstName + ' ' + u.LastName) AS FullName, -- FirstName ve LastName birleştiriliyor
            i.status, 
            i.brand, 
            i.model, 
            i.location, 
            i.department
        FROM inventory i
        LEFT JOIN users u ON i.userID = u.userID
        WHERE i.userID = @userId"; // userId'ye göre filtreleme

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable inventoryTable = new DataTable();
                    adapter.Fill(inventoryTable);
                    return inventoryTable;
                }
            }
        }



        // Yeni envanter öğesi ekle
        public void AddInventoryItem(Item item) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"
    INSERT INTO inventory (
        itemName, itemType, serialNumber, brand, model, purchaseDate, 
        warrantyEndDate, cost, taxRate, photo, location, 
        department, userID, status, lastMaintenanceDate, notes, created_at, updated_at, reminderStatus
    ) VALUES (
        @itemName, @itemType, @serialNumber, @brand, @model, @purchaseDate, 
        @warrantyEndDate,  @cost, @taxRate, @photo, @location, 
        @department, @userID, @status, @lastMaintenanceDate, @notes, @createdAt, @updatedAt, @reminderStatus
    )";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@itemType", item.ItemType);
                    cmd.Parameters.AddWithValue("@serialNumber", (object)item.SerialNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@brand", (object)item.Brand ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@model", (object)item.Model ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@purchaseDate", (object)item.PurchaseDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@warrantyEndDate", (object)item.WarrantyEndDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cost", (object)item.Cost ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@taxRate", (object)item.TaxRate ?? DBNull.Value);
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = (object)item.Photo ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@location", (object)item.Location ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@department", (object)item.Department ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@userID", (object)item.UserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", (object)item.Status ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lastMaintenanceDate", (object)item.LastMaintenanceDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@notes", (object)item.Notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@reminderStatus", item.ReminderStatus); // Yeni eklenen sütun

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        // Mevcut envanter öğesini güncelle
        public void UpdateInventoryItem(Item item, int? itemID) {
            string ID;
            if (!itemID.HasValue) {
                MessageBox.Show("Lütfen bir ekipman seçin.");
                return;
            } else {
                ID = "TTO" + itemID.ToString();
            }

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"
    UPDATE inventory SET 
        itemName = @itemName, 
        itemType = @itemType, 
        serialNumber = @serialNumber, 
        brand = @brand, 
        model = @model, 
        purchaseDate = @purchaseDate, 
        warrantyEndDate = @warrantyEndDate,
        cost = @cost, 
        taxRate = @taxRate, 
        photo = @photo, 
        location = @location, 
        department = @department, 
        userID = @userID, 
        status = @status, 
        lastMaintenanceDate = @lastMaintenanceDate, 
        notes = @notes, 
        updated_at = @updatedAt, 
        reminderStatus = @reminderStatus
    WHERE itemID = @itemID";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@itemID", ID);
                    cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                    cmd.Parameters.AddWithValue("@itemType", item.ItemType);
                    cmd.Parameters.AddWithValue("@serialNumber", (object)item.SerialNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@brand", (object)item.Brand ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@model", (object)item.Model ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@purchaseDate", (object)item.PurchaseDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@warrantyEndDate", (object)item.WarrantyEndDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cost", (object)item.Cost ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@taxRate", (object)item.TaxRate ?? DBNull.Value);
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = (object)item.Photo ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@location", (object)item.Location ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@department", (object)item.Department ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@userID", (object)item.UserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", (object)item.Status ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@lastMaintenanceDate", (object)item.LastMaintenanceDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@notes", (object)item.Notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@reminderStatus", item.ReminderStatus); // Yeni eklenen sütun

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void DeleteInventoryItem(string itemID) {
            if (String.IsNullOrEmpty(itemID)) {
                MessageBox.Show("Geçerli bir ekipman seçin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "DELETE FROM inventory WHERE itemID = @itemID";

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@itemID", itemID);

                    try {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0) {
                            MessageBox.Show("Ekipman başarıyla silindi.");
                        } else {
                            MessageBox.Show("Ekipman bulunamadı.");
                        }
                    } catch (Exception ex) {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }


        public byte isAdmin(int userID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT isAdmin FROM Users WHERE UserID = @UserID";
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    // Parametre ekleyerek sorguyu güvenli hale getiriyoruz
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    // isAdmin değerini al
                    var result = cmd.ExecuteScalar(); 
                    return Convert.ToByte(result);
  
                }
            }
        }

        public bool InsertRequest(int userID, RichTextBox box) {
     
            string query = "INSERT INTO Requests (userID, note) VALUES (@userID, @note)";

            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        // Parametreleri ekleyelim
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(box.Text) ? DBNull.Value : (object)box.Text);

                        // Bağlantıyı aç ve sorguyu çalıştır
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Eğer 1 veya daha fazla satır eklendiyse işlem başarılı
                        return rowsAffected > 0;
                    }
                }
            } catch (Exception ex) {
                // Hata durumunda loglama yapılabilir
                MessageBox.Show("Hata: " + ex.Message);
                return false;
            }
        }

        public List<Tuple<DateTime, string, bool>> GetRequest(int? userID) {
            List<Tuple<DateTime, string, bool>> requestList = new List<Tuple<DateTime, string, bool>>();

            string query = "SELECT createTime, note, isComplete FROM Requests";

            if (userID.HasValue) {
                query += " WHERE userID = @userID";
            }

            query += " ORDER BY createTime DESC";

            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        if (userID.HasValue) {
                            cmd.Parameters.AddWithValue("@userID", userID.Value);
                        }

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime createTime = (DateTime)reader["createTime"];
                                string note = (string)reader["note"];
                                bool isComplete = (bool)reader["isComplete"];

                                requestList.Add(new Tuple<DateTime, string, bool>(createTime, note, isComplete));
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Talepler getirilirken hata oluştu: " + ex.Message);
            }

            return requestList;
        }

        public List<Tuple<int, DateTime, string, string>> GetAllRequests() {
            List<Tuple<int, DateTime, string, string>> requestList = new List<Tuple<int, DateTime, string, string>>();

            string query = @"
        SELECT 
            R.RequestID,
            R.createTime, 
            R.note, 
            CASE 
                WHEN R.isComplete = 1 THEN 'Tamamlandı' 
                ELSE 'Beklemede' 
            END AS Status, 
            U.FirstName + ' ' + U.LastName AS UserFullName
        FROM Requests R
        JOIN Users U ON R.userID = U.UserID
        ORDER BY R.createTime DESC";

            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader()) {
                            while (reader.Read()) {
                                int requestID = (int)reader["RequestID"];
                                DateTime createTime = (DateTime)reader["createTime"];
                                string note = reader["note"] != DBNull.Value ? (string)reader["note"] : string.Empty;
                                string status = (string)reader["Status"];
                                string userFullName = (string)reader["UserFullName"];

                                requestList.Add(new Tuple<int, DateTime, string, string>(requestID, createTime, note, $"{userFullName} - {status}"));
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Talepler getirilirken hata oluştu: " + ex.Message);
            }

            return requestList;
        }

        public bool ConfirmRequest(int requestID) {
            string query = "UPDATE Requests SET isComplete = 1 WHERE RequestID = @RequestID";

            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0; // En az bir satır güncellendiyse true döndür
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Talep onaylanırken hata oluştu: " + ex.Message);
                return false;
            }
        }

        public bool DeleteRequest(int requestID) {
            string query = "DELETE FROM Requests WHERE RequestID = @RequestID";

            try {
                using (SqlConnection conn = new SqlConnection(connectionString)) {
                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@RequestID", requestID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0; // Eğer en az bir satır silindiyse true döner
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Talep silinirken hata oluştu: " + ex.Message);
                return false;
            }
        }

        public int CountInventory(int userID) {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM inventory WHERE userID = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        cmd.Parameters.AddWithValue("@userID", userID);

                        // Sayıyı al
                        count = (int)cmd.ExecuteScalar();
                    }
                } catch (Exception ex) {
                    // Hata durumu, örneğin loglama yapılabilir
                    Console.WriteLine(ex.Message);
                }
            }
            return count;
        }

        public int CountAllInventories() {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                try {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM inventory";

                    using (SqlCommand cmd = new SqlCommand(query, conn)) {
                        // Sayıyı al
                        count = (int)cmd.ExecuteScalar();
                    }
                } catch (Exception ex) {
                    // Hata durumu, örneğin loglama yapılabilir
                    Console.WriteLine(ex.Message);
                }
            }
            return count;
        }

        public List<string> GetReminds(int? userID) {
            List<string> reminders = new List<string>();

            string query = @"
        SELECT itemID, itemName, DATEDIFF(DAY, GETDATE(), warrantyEndDate) AS RemainingDays
        FROM inventory
        WHERE (@userID IS NULL OR userID = @UserID)
          AND warrantyEndDate BETWEEN GETDATE() AND DATEADD(MONTH, 1, GETDATE())";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@UserID", (object)userID ?? DBNull.Value);  // Null ise DBNull.Value gönder

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            string itemID = reader["itemID"].ToString();
                            string itemName = reader["itemName"].ToString();
                            int remainingDays = Convert.ToInt32(reader["RemainingDays"]);

                            // Mesajı oluştur
                            string reminderMessage = $"{itemID} {itemName} adlı ürünün garanti süresine {remainingDays} gün kaldı.";
                            reminders.Add(reminderMessage);
                        }
                    }
                }
            }
            return reminders;
        }

    }
}


