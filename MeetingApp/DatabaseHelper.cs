using MeetingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;


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
                string query = "SELECT userID, isAdmin FROM users WHERE username = @username AND userPassword = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    int userId = reader.GetInt32(reader.GetOrdinal("userID"));
                    bool isAdmin = reader.GetBoolean(reader.GetOrdinal("isAdmin"));
                    return new User { UserID = userId, IsAdmin = isAdmin };
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

        public void RegisterUser(string username, string firstName, string lastName, string email, string companyName, string title, string phoneNumber, string password, bool isAdmin, string position, bool isValid) {
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

        public bool UpdateUser(int userID, string username, string firstName, string lastName, string email, string companyName, string title, string phoneNumber, string password, bool isAdmin, string position) {
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

                    // 1. Adım: MeetingParticipants tablosundan kullanıcıya ait tüm katılımcıları sil
                    string query1 = "DELETE FROM MeetingParticipants WHERE ParticipantType = 'User' AND ParticipantID = @UserID";
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn, transaction)) {
                        cmd1.Parameters.AddWithValue("@UserID", userId);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2. Adım: Users tablosundan kullanıcıyı sil
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
                string query = "SELECT companyID, name FROM Companies";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable companies = new DataTable();
                adapter.Fill(companies);
                return companies;
            }
        }

        public DataTable GetCandidateCompanies() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT CompanyID, Name, FieldsOfActivity, Phone, Points FROM CandidateCompanies";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable companies = new DataTable();
                adapter.Fill(companies);
                return companies;
            }
        }

        public bool AddEmployee(string firstName, string lastName, int companyID, string email, string phone, string title, string position) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "INSERT INTO Employees (firstname, lastname, companyID, email, phone, title, position) VALUES (@FirstName, @LastName, @CompanyID, @Email, @Phone, @Title, @Position)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@CompanyID", companyID);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Position", position);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                return result > 0;
            }
        }
        public bool UpdateEmployee(int employeeID, string firstName, string lastName, int companyID, string email, string phone, string title, string position) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = @"UPDATE Employees 
                         SET FirstName = @FirstName, 
                             LastName = @LastName, 
                             CompanyID = @CompanyID, 
                             Email = @Email, 
                             Phone = @Phone, 
                             Title = @Title, 
                             Position = @Position 
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

        public bool AddAcademic(string firstName, string lastName, string email, string phone, string title, string position) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "INSERT INTO Academics (FirstName, LastName, Email, Phone, Title, Position) VALUES (@FirstName, @LastName, @Email, @Phone, @Title, @Position)";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Position", position);

                        int result = command.ExecuteNonQuery();

                        // Eğer etkilenen satır sayısı 1 ise ekleme başarılı olmuştur
                        return result > 0;
                    }
                } catch (Exception ex) {
                    // Hata yönetimi burada yapılabilir (örneğin, loglama veya hata mesajı)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UpdateAcademic(int academicID, string firstName, string lastName, string email, string phone, string title, string position) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();

                    string query = "UPDATE Academics SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Title = @Title, Position = @Position WHERE AcademicID = @AcademicID";

                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@AcademicID", academicID);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Position", position);

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
                string query = "SELECT userID, username, firstName, lastName FROM users";
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
                    string query = "SELECT AcademicID, FirstName, LastName FROM Academics";
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
                    string query = "SELECT FirstName, LastName, Email, Phone, Title, Position FROM Academics WHERE AcademicID = @AcademicID";
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
                string query = "SELECT EmployeeID, CONCAT(FirstName, ' ', LastName) AS FullName FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }

        public DataTable GetDetailsEmployee(int EmployeeID) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "SELECT FirstName, LastName, Email, Phone, Title, Position, CompanyID FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }



        public int AddMeeting(Meeting meeting) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "INSERT INTO Meetings (MeetingDate, MeetingTime, MeetingTitle, MeetingNotes ,MeetingLocation) OUTPUT INSERTED.MeetingID VALUES (@Date, @Time, @Title, @Notes, @Location)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", meeting.Date);
                cmd.Parameters.AddWithValue("@Time", meeting.Time);
                cmd.Parameters.AddWithValue("@Title", meeting.Title);
                cmd.Parameters.AddWithValue("@Notes", meeting.Notes);
                cmd.Parameters.AddWithValue("@Location", meeting.Location);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public void UpdateMeeting(Meeting meeting) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                string query = "UPDATE Meetings SET MeetingDate = @Date, MeetingTime = @Time, MeetingTitle = @Title, MeetingNotes = @Notes, MeetingLocation = @Location WHERE MeetingID = @MeetingID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", meeting.Date);
                cmd.Parameters.AddWithValue("@Time", meeting.Time);
                cmd.Parameters.AddWithValue("@Title", meeting.Title);
                cmd.Parameters.AddWithValue("@Notes", meeting.Notes);
                cmd.Parameters.AddWithValue("@Location", meeting.Location);
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

                    // 2. Adım: Meetings tablosundan toplantıyı sil
                    string query2 = "DELETE FROM Meetings WHERE MeetingID = @MeetingID";
                    using (SqlCommand cmd2 = new SqlCommand(query2, conn, transaction)) {
                        cmd2.Parameters.AddWithValue("@MeetingID", meetingId);
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



        public void AddMeetingDocument(int meetingId, byte[] documentData) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                //update document
                if (documentData != null) {
                    string fileQuery = "UPDATE Meetings SET Documents = @Documents WHERE MeetingID = @MeetingID";
                    using (SqlCommand fileCmd = new SqlCommand(fileQuery, conn)) {
                        fileCmd.Parameters.AddWithValue("@MeetingID", meetingId);
                        fileCmd.Parameters.AddWithValue("@Documents", documentData);

                        fileCmd.ExecuteNonQuery();
                    }
                }
            }
        }
        //export docx

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

        private byte[] GetDocumentByMeetingID(int meetingId) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = "SELECT Documents FROM Meetings WHERE MeetingID = @MeetingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MeetingID", meetingId);

                connection.Open();
                byte[] documentData = command.ExecuteScalar() as byte[];

                return documentData;
            }
        }
        private string DetermineFileExtension(byte[] fileData) {
            if (fileData.Length > 4) {
                // PDF dosyaları "%PDF-" ile başlar
                if (fileData[0] == 0x25 && fileData[1] == 0x50 && fileData[2] == 0x44 && fileData[3] == 0x46)
                    return "pdf";

                // DOCX ve diğer Office dosyaları ZIP formatında olur, ilk iki bayt "PK" (0x50, 0x4B) ile başlar
                if (fileData[0] == 0x50 && fileData[1] == 0x4B)
                    return "docx"; // Burada varsayılan olarak DOCX dönebiliriz, ama diğer türleri de kontrol edebiliriz.

                // PNG dosyaları "\x89PNG" ile başlar
                if (fileData[0] == 0x89 && fileData[1] == 0x50 && fileData[2] == 0x4E && fileData[3] == 0x47)
                    return "png";

                // JPG/JPEG dosyaları "\xFF\xD8\xFF" ile başlar
                if (fileData[0] == 0xFF && fileData[1] == 0xD8 && fileData[2] == 0xFF)
                    return "jpg";
            }

            return "unknown";
        }

        public void ViewDocument(int meetingId) {
            byte[] documentData = GetDocumentByMeetingID(meetingId);

            if (documentData != null) {
                // Dosya türünü belirle
                string fileExtension = DetermineFileExtension(documentData);

                if (fileExtension == "unknown") {
                    MessageBox.Show("Bilinmeyen bir dosya türü. Görüntüleme işlemi başarısız oldu.");
                    return;
                }

                // Geçici dosya yolunu oluştur
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"MeetingDocument_{meetingId}.{fileExtension}");

                // Dökümanı geçici dosya olarak kaydet
                File.WriteAllBytes(tempFilePath, documentData);

                // Dosyayı varsayılan uygulama ile aç
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempFilePath) { UseShellExecute = true });
            } else {
                MessageBox.Show("Döküman bulunamadı.");
            }
        }

        public DataTable GetParticipantDetailsById(int participantId, string participantType) {
            string query = "";

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

            return allData;
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

        public DataTable LoadEvents(int year, int month) {
            string query = "SELECT MeetingDate, MeetingTitle FROM Meetings WHERE YEAR(MeetingDate) = @year AND MONTH(MeetingDate) = @month";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@month", month);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable meetingsTable = new DataTable();
                adapter.Fill(meetingsTable);
                return meetingsTable;
            }
        }

        public List<Meeting> GetMeetingsWithSelectedParticipantsAndDateRange(int? companyId, int? userId, int? academicId, DateTime? dateTimeStart, DateTime? dateTimeEnd) {
            // Eğer hiçbir participant seçilmediyse, boş liste döndür.
            if (!companyId.HasValue && !userId.HasValue && !academicId.HasValue) {
                return new List<Meeting>();
            }

            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();

                var query = new StringBuilder();
                query.AppendLine("SELECT DISTINCT m.MeetingID, m.MeetingTitle, m.MeetingDate");
                query.AppendLine("FROM Meetings m");

                // Seçili olan participant'lara göre join ekleme
                if (companyId.HasValue) {
                    query.AppendLine("INNER JOIN MeetingParticipants mp1 ON m.MeetingID = mp1.MeetingID AND mp1.ParticipantType = 'Company' AND mp1.ParticipantID = @CompanyId");
                }
                if (userId.HasValue) {
                    query.AppendLine("INNER JOIN MeetingParticipants mp2 ON m.MeetingID = mp2.MeetingID AND mp2.ParticipantType = 'User' AND mp2.ParticipantID = @UserId");
                }
                if (academicId.HasValue) {
                    query.AppendLine("INNER JOIN MeetingParticipants mp3 ON m.MeetingID = mp3.MeetingID AND mp3.ParticipantType = 'Academic' AND mp3.ParticipantID = @AcademicId");
                }

                query.AppendLine("WHERE 1 = 1");  // Dinamik WHERE koşulları için

                // Tarih aralığı filtreleme durumu
                if (dateTimeStart.HasValue && dateTimeEnd.HasValue) {
                    query.AppendLine("AND m.MeetingDate BETWEEN @StartDate AND @EndDate");
                }

                using (var command = new SqlCommand(query.ToString(), connection)) {
                    // Parametreleri ekleme
                    if (companyId.HasValue) {
                        command.Parameters.AddWithValue("@CompanyId", companyId.Value);
                    }
                    if (userId.HasValue) {
                        command.Parameters.AddWithValue("@UserId", userId.Value);
                    }
                    if (academicId.HasValue) {
                        command.Parameters.AddWithValue("@AcademicId", academicId.Value);
                    }

                    // Tarih aralığı için parametreleri ekle
                    if (dateTimeStart.HasValue && dateTimeEnd.HasValue) {
                        command.Parameters.AddWithValue("@StartDate", dateTimeStart.Value);
                        command.Parameters.AddWithValue("@EndDate", dateTimeEnd.Value);
                    }

                    var meetings = new List<Meeting>();

                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var meeting = new Meeting {
                                MeetingID = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Date = reader.GetDateTime(2)
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
    }
}

