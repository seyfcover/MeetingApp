using System;

public class Item
{
    public int? ItemID { get; set; } // Otomatik artan benzersiz kimlik
    public string ItemName { get; set; } // Ekipman adı
    public string ItemType { get; set; } // Ekipman türü
    public string SerialNumber { get; set; } // Benzersiz seri numarası
    public string Brand { get; set; } // Marka
    public string Model { get; set; } // Model
    public DateTime? PurchaseDate { get; set; } // Satın alma tarihi
    public DateTime? WarrantyEndDate { get; set; } // Garanti bitiş tarihi
    public decimal? Cost { get; set; } // Satın alma maliyeti
    public decimal? TaxRate { get; set; } // KDV oranı
    public byte[] Photo { get; set; } // Ekipman fotoğrafı
    public string Location { get; set; } // Fiziksel konum
    public string Department { get; set; } // Bağlı olduğu departman
    public int? UserID { get; set; } // Kullanıcı atanmadığında null olabilir
    public string Status { get; set; } // Durum (Mevcut, Bakımda vb.)
    public DateTime? LastMaintenanceDate { get; set; } // Son bakım tarihi
    public string Notes { get; set; } // Ek açıklamalar
    public DateTime? CreatedAt { get; set; } // Kaydın oluşturulma zamanı
    public DateTime? UpdatedAt { get; set; } // Kaydın güncellenme zamanı

    // Kurucu (Constructor)
    public Item(string itemName, string itemType, string serialNumber, string brand, string model,
                DateTime? purchaseDate, DateTime? warrantyEndDate, decimal? cost, decimal? taxRate, byte[] photo, string location, string department, int? userID,
                string status, DateTime? lastMaintenanceDate, string notes, DateTime? createdAt, DateTime? updatedAt) {
        ItemName = itemName;
        ItemType = itemType;
        SerialNumber = serialNumber;
        Brand = brand;
        Model = model;
        PurchaseDate = purchaseDate;
        WarrantyEndDate = warrantyEndDate;
        Cost = cost;
        TaxRate = taxRate;
        Photo = photo;
        Location = location;
        Department = department;
        UserID = userID;
        Status = status;
        LastMaintenanceDate = lastMaintenanceDate;
        Notes = notes;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
