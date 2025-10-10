# MvcStok

[TR]

**Stok Takip ve Envanter Yönetim Sistemi (ASP.NET MVC)**

---

## 💻 Proje Hakkında

Bu proje, temel **stok takibi ve envanter yönetimi** ihtiyaçlarını karşılamak üzere **ASP.NET MVC** kullanılarak geliştirilmiştir. Ürünlerin, kategorilerin ve tedarikçilerin sisteme kaydını, takibini ve yönetimini sağlayarak işletmelerin stok süreçlerini düzenlemeyi amaçlar. Proje, özellikle MVC mimarisini uygulamalı olarak öğrenmek için iyi bir örnek teşkil eder.

---

## ✨ Temel Özellikler

### Teknik Özellikler

* **ASP.NET MVC (Model-View-Controller)**: Geleneksel MVC mimarisi kullanılmıştır.
* **Entity Framework (Code First/Database First)**: Veritabanı ile etkileşim (Hangi yaklaşım kullanılıyorsa belirtilebilir).
* **Veri Doğrulama**: Model bazlı doğrulama (Validation) kullanımı.
* **CRUD Operasyonları**: Ürün, Kategori ve Müşteri/Tedarikçi gibi temel varlıklar üzerinde oluşturma, okuma, güncelleme ve silme işlemleri.
* **Arama ve Filtreleme**: Stok listelerinde arama ve filtreleme özellikleri.
* **ViewBag/ViewData Kullanımı**: Controller'dan View'e veri taşıma yöntemleri.

### Kullanıcı / Panel Özellikleri

* **Ürün Yönetimi**: Stoktaki ürünlerin detaylı kaydı, durumu ve takibi.
* **Kategori Yönetimi**: Ürünleri gruplamak için kategori tanımlama ve düzenleme.
* **Müşteri/Tedarikçi Yönetimi**: İşletmenin çalıştığı kişi/kurumların kaydı ve takibi.
* **Basit Raporlama**: Stok durumu, kritik stok seviyeleri gibi basit listelerin görüntülenmesi.
* **Kullanıcı Girişi**: Yöneticilerin sisteme güvenli bir şekilde erişimi.

---

### 🚀 Nasıl Çalıştırılır?

Bu projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

1.  **Gereksinimler:**
    * [.NET Framework (4.x veya üzeri)](https://dotnet.microsoft.com/download/dotnet-framework)
    * [SQL Server](https://www.microsoft.com/en-us/sql-server) (veya SQL Server Express)
    * [Visual Studio 2019/2022](https://visualstudio.microsoft.com/) (Önerilen)

2.  **Projeyi Klonlama:**
    ```bash
    git clone [https://github.com/abdullahhaktan/MvcStok.git](https://github.com/abdullahhaktan/MvcStok.git)
    cd MvcStok
    ```

3.  **Bağımlılıkları Yükleme:**
    * Visual Studio'yu açın.
    * Çözüm Gezgini'nde projenin üzerine sağ tıklayıp **"Manage NuGet Packages..."** (NuGet Paketlerini Yönet) seçeneğini açın.
    * Gerekli tüm paketlerin (örneğin Entity Framework) indirildiğinden emin olmak için **"Restore"** (Geri Yükle) düğmesine tıklayın.

4.  **Veritabanı Ayarları:**
    * Projenin `Web.config` dosyasını açın.
    * `connectionStrings` bölümündeki veritabanı bağlantı dizesini (`DefaultConnection` veya benzeri) kendi yerel SQL Server ayarlarınıza göre güncelleyin.
    * *(Not: Veritabanının manuel olarak oluşturulması veya EF Migrations kullanılması gerekebilir. Geleneksel MVC projelerinde genellikle Database First yaklaşımı yaygındır.)*

5.  **Projeyi Çalıştırma:**
    * Projeyi Visual Studio'da çalıştırın (F5 veya `Start` butonu).
    * Uygulama genellikle tarayıcınızda açılacaktır. İlk erişim için **`/GirisYap/Index`** gibi bir giriş sayfası yolu kullanılması gerekebilir.

---
---

[EN]

# MvcStok

## 💻 About the Project

This project is an **inventory tracking and stock management system** developed using **ASP.NET MVC**. Its purpose is to register, track, and manage products, categories, and suppliers, helping businesses organize their inventory processes. The project serves as a practical example for learning the MVC architecture.

---

## ✨ Core Features

### Technical Features

* **ASP.NET MVC (Model-View-Controller)**: Utilizes the traditional MVC architectural pattern.
* **Entity Framework (Code First/Database First)**: Interaction with the database (Specify the approach used if known).
* **Data Validation**: Use of model-based validation.
* **CRUD Operations**: Create, Read, Update, and Delete operations for core entities like Products, Categories, and Customers/Suppliers.
* **Search and Filtering**: Functionality for searching and filtering stock lists.
* **ViewBag/ViewData Usage**: Methods for transferring data from the Controller to the View.

### User / UI Features

* **Product Management**: Detailed registration, status, and tracking of products in stock.
* **Category Management**: Defining and managing categories to group products.
* **Customer/Supplier Management**: Tracking entities the business works with.
* **Basic Reporting**: Viewing simple lists such as stock status and critical stock levels.
* **User Login**: Secure access to the system for administrators.

---

### 🚀 How to Run

Follow these steps to set up and run the project locally:

1.  **Prerequisites:**
    * [.NET Framework (4.x or higher)](https://dotnet.microsoft.com/download/dotnet-framework)
    * [SQL Server](https://www.microsoft.com/en-us/sql-server) (or SQL Server Express)
    * [Visual Studio 2019/2022](https://visualstudio.microsoft.com/) (Recommended)

2.  **Cloning the Project:**
    ```bash
    git clone [https://github.com/abdullahhaktan/MvcStok.git](https://github.com/abdullahhaktan/MvcStok.git)
    cd MvcStok
    ```

3.  **Installing Dependencies:**
    * Open the project in Visual Studio.
    * Right-click the project in Solution Explorer and open **"Manage NuGet Packages..."**.
    * Click the **"Restore"** button to ensure all necessary packages (e.g., Entity Framework) are downloaded.

4.  **Database Configuration:**
    * Open the project's `Web.config` file.
    * Update the database connection string (`DefaultConnection` or similar) in the `connectionStrings` section to match your local SQL Server settings.
    * *(Note: The database may need to be created manually or by using EF Migrations. The Database First approach is often common in traditional MVC projects.)*

5.  **Running the Project:**
    * Run the project in Visual Studio (F5 or the `Start` button).
    * The application will typically open in your browser. Initial access may require navigating to a login page such as **`/GirisYap/Index`**.
