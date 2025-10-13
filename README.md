# MvcStok

[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Design Pattern](https://img.shields.io/badge/Architecture-N--Tier%2FLayered-orange.svg)]()
[![GitHub repo size](https://img.shields.io/github/repo-size/abdullahhaktan/MvcStok)](https://github.com/abdullahhaktan/MvcStok)
[![GitHub Yıldızları](https://img.shields.io/github/stars/abdullahhaktan/MvcStok.svg?style=social)](https://github.com/abdullahhaktan/MvcStok/stargazers)
[![Lisans](https://img.shields.io/badge/Lisans-MIT-blue.svg)](LICENSE)

[TR]

**Stok Takip ve Envanter Yönetim Sistemi (ASP.NET MVC)**

---

## 💻 Proje Hakkında

Bu proje, temel **stok takibi ve envanter yönetimi** ihtiyaçlarını karşılamak üzere geleneksel **ASP.NET MVC (.NET Framework)** kullanılarak geliştirilmiştir. Ürünlerin, kategorilerin ve tedarikçilerin sisteme kaydını, takibini ve yönetimini sağlar. Proje, **Database First** yaklaşımını kullanır ve veritabanı şemasını manuel kurulum gerektirir.

---

## ✨ Temel Özellikler

### Teknik Özellikler

* **ASP.NET MVC (.NET Framework)**: Geleneksel Model-View-Controller mimarisi.
* **Database First Yaklaşımı**: Modeller, önceden var olan veritabanı şemasından oluşturulmuştur.
* **Entity Framework (EF)**: Veritabanı ile etkileşim (Migrations kullanılmamaktadır).
* **CRUD Operasyonları**: Ürün, Kategori ve diğer temel varlıklar üzerinde oluşturma, okuma, güncelleme ve silme işlemleri.
* **Veri Doğrulama**: Model bazlı doğrulama (Validation) kullanımı.

### Kullanıcı / Panel Özellikleri

* **Ürün Yönetimi**: Stoktaki ürünlerin detaylı kaydı ve takibi.
* **Kategori Yönetimi**: Ürünleri gruplamak için kategori tanımlama.
* **Müşteri/Tedarikçi Yönetimi**: İşletmenin çalıştığı kişi/kurumların kaydı.
* **Arama ve Filtreleme**: Stok listelerinde arama ve filtreleme özellikleri.

---

### 🚀 Nasıl Çalıştırılır?

Bu projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin:

1.  **Gereksinimler:**
    * **[.NET Framework (4.x veya üzeri)](https://dotnet.microsoft.com/download/dotnet-framework)**
    * **[SQL Server](https://www.microsoft.com/en-us/sql-server)** (veya SQL Server Express)
    * **[Visual Studio 2019/2022](https://visualstudio.microsoft.com/)** (Önerilen)

2.  **Projeyi Klonlama:**
    ```bash
    git clone [https://github.com/abdullahhaktan/MvcStok.git](https://github.com/abdullahhaktan/MvcStok.git)
    cd MvcStok
    ```

3.  **Bağımlılıkları Yükleme:**
    * Visual Studio'da projeyi açın.
    * Çözüm Gezgini'nde projeye sağ tıklayıp **"Manage NuGet Packages..."** (NuGet Paketlerini Yönet) seçeneğini açın ve tüm paketlerin **Restore** edildiğinden emin olun.

4.  **Veritabanı Ayarları:**
    * Projenin **`Web.config`** dosyasını açın.
    * **`connectionStrings`** bölümündeki bağlantı dizesini kendi yerel SQL Server ayarlarınıza göre güncelleyin.
    * *(Not: Bu dizedeki veritabanı adı, manuel olarak oluşturacağınız veritabanı adıyla eşleşmelidir.)*

5.  **Veritabanını Oluşturma (ZORUNLU MANUEL ADIM):**
    * Migrations kullanılmadığı için veritabanını manuel olarak oluşturmanız gerekmektedir.

6.  **Projeyi Çalıştırma:**
    * Projeyi Visual Studio'da çalıştırın (F5 veya `Start` butonu).
    * Uygulama genellikle tarayıcınızda açılacaktır. İlk erişim için bir giriş sayfası yolu kullanılması gerekebilir.

---
---

[EN]

# MvcStok

## 💻 About the Project

This project is an **inventory tracking and stock management system** developed using traditional **ASP.NET MVC (.NET Framework)**. It handles the registration, tracking, and management of products, categories, and suppliers. The project uses the **Database First** approach and requires manual setup of the database schema.

---

## ✨ Core Features

### Technical Features

* **ASP.NET MVC (.NET Framework)**: Traditional Model-View-Controller architecture.
* **Database First Approach**: Models are scaffolded from an existing database schema.
* **Entity Framework (EF)**: Interaction with the database (Migrations are not used).
* **CRUD Operations**: Create, Read, Update, and Delete operations for products, categories, and other core entities.
* **Data Validation**: Use of model-based validation.

### User / UI Features

* **Product Management**: Detailed registration and tracking of products in stock.
* **Category Management**: Defining categories to group products.
* **Customer/Supplier Management**: Tracking entities the business works with.
* **Search and Filtering**: Functionality for searching and filtering stock lists.

---

### 🚀 How to Run

Follow these steps to set up and run the project locally:

1.  **Prerequisites:**
    * **[.NET Framework (4.x or higher)](https://dotnet.microsoft.com/download/dotnet-framework)**
    * **[SQL Server](https://www.microsoft.com/en-us/sql-server)** (or SQL Server Express)
    * **[Visual Studio 2019/2022](https://visualstudio.microsoft.com/)** (Recommended)

2.  **Cloning the Project:**
    ```bash
    git clone [https://github.com/abdullahhaktan/MvcStok.git](https://github.com/abdullahhaktan/MvcStok.git)
    cd MvcStok
    ```

3.  **Installing Dependencies:**
    * Open the project in Visual Studio.
    * Right-click the project in Solution Explorer, open **"Manage NuGet Packages..."**, and ensure all packages are **Restored**.

4.  **Database Configuration:**
    * Open the project's **`Web.config`** file.
    * Update the connection string in the **`connectionStrings`** section to match your local SQL Server settings.
    * *(Note: The database name in this string must match the name of the database you create manually.)*

5.  **Creating the Database (REQUIRED MANUAL STEP):**
    * Since Migrations are not used, you must create the database manually.
    * Locate the **SQL script file** (`.sql` extension) within the project's root or a subfolder.
    * Use a tool like SQL Server Management Studio (SSMS) to run this script and **create the database schema**.

6.  **Running the Project:**
    * Run the project in Visual Studio (F5 or the `Start` button).
    * The application will typically open in your browser. Access may require navigating to a login page.
