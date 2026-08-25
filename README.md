# Filo Yenileme Karar Destek Sistemi

Filo Yenileme Karar Destek Sistemi, araç filolarının yenilenme süreçlerini daha sistematik ve veriye dayalı şekilde değerlendirmek amacıyla geliştirilmiş bir masaüstü uygulamasıdır.

## Projenin Amacı

Bu proje; filodaki araçların bakım, maliyet ve kullanım verilerini değerlendirerek araç yenileme kararlarının alınmasına destek olmayı amaçlamaktadır.

## Özellikler

* Araç bilgilerinin yönetimi
* Bakım kayıtlarının takibi
* Araç ve filo maliyetlerinin değerlendirilmesi
* Filo yenileme kararlarının desteklenmesi
* AHP yöntemi ile kriter ağırlıklandırma
* TOPSIS yöntemi ile araçların değerlendirilmesi ve sıralanması
* Analiz sonuçlarının görüntülenmesi
* Raporlama işlemleri
* SQLite tabanlı veri yönetimi

## Kullanılan Teknolojiler

* C#
* WPF
* XAML
* SQLite
* Entity Framework Core
* AHP (Analytic Hierarchy Process)
* TOPSIS (Technique for Order Preference by Similarity to Ideal Solution)

## Proje Yapısı

* `Gorunumler` — Uygulamanın kullanıcı arayüzleri
* `GorunumModelleri` — Görünümlere ait ViewModel yapıları
* `Modeller` — Veri modelleri
* `Servisler` — Uygulamanın servis ve karar destek işlemleri
* `Veri` — Veritabanı bağlantısı ve DbContext yapısı
* `Migrations` — Veritabanı migration dosyaları
* `Kaynaklar` — XAML stil ve tasarım kaynakları

## Karar Destek Yaklaşımı

Sistem, çok kriterli karar verme yöntemlerinden AHP ve TOPSIS yöntemlerinden yararlanarak filo içerisindeki araçların belirlenen kriterler doğrultusunda değerlendirilmesine yardımcı olur.

AHP yöntemi kriterlerin önem ağırlıklarının belirlenmesinde, TOPSIS yöntemi ise araçların bu kriterlere göre değerlendirilerek sıralanmasında kullanılmaktadır.

## Geliştirme Ortamı

Proje Microsoft Visual Studio kullanılarak C# ve WPF teknolojileri ile geliştirilmiştir.

##  Projeyi İndirme ve Çalıştırma

Bu proje **C# / WPF ve .NET 10** kullanılarak geliştirilmiştir. Projeyi çalıştırmadan önce bilgisayarınızda gerekli geliştirme ortamının kurulu olması gerekir.

### 1. Projeyi GitHub'dan İndirin

GitHub üzerindeki proje sayfasına girin.

**Code** butonuna tıklayın.

Ardından:

**Download ZIP**

seçeneğine basarak projeyi bilgisayarınıza indirin.

---

### 2. ZIP Dosyasını Ayıklayın

İndirilen `.zip` dosyasını doğrudan açıp proje içerisinden çalıştırmaya çalışmayın.

Öncelikle ZIP dosyasının bulunduğu klasöre gidin.

ZIP dosyasına sağ tıklayın.

Windows'ta:

**Tümünü Ayıkla / Extract All**

seçeneğine tıklayın.

Ayıklanacak konumu seçtikten sonra:

**Ayıkla / Extract**

butonuna basın.

İşlem tamamlandığında normal bir proje klasörü oluşacaktır.

> ⚠️ Projeyi mutlaka ayıklanan klasör içerisinden açın. ZIP dosyasının içerisinden çalıştırmayın.

---

### 3. Gerekli .NET Sürümünü Kontrol Edin

Bu proje:

**.NET 10**

kullanmaktadır.

Bilgisayarınızda .NET SDK'nın kurulu olup olmadığını kontrol etmek için Terminal veya Komut İstemi'ni açın ve:

```bash
dotnet --version
```

komutunu çalıştırın.

.NET 10 kurulu değilse **.NET 10 SDK** kurulmalıdır.

---

### 4. Projeyi VS Code ile Açma

Visual Studio Code'u açın.

Üst menüden:

**File → Open Folder**

seçeneğine girin.

ZIP'ten çıkardığınız **FiloYenile proje klasörünü** seçin.

Doğru klasörün içerisinde aşağıdakilere benzer dosyalar bulunmalıdır:

```text
FiloYenile.csproj
App.xaml
MainWindow.xaml
Models
Views
ViewModels
Services
```

> Sadece `FiloYenile.csproj` dosyasını açmak yerine projenin bulunduğu **ana klasörü açmanız önerilir.**

---

### 5. Workspace'e Güvenin

VS Code projeyi ilk kez açtığında:

**Do you trust the authors of the files in this folder?**

şeklinde bir uyarı gösterebilir.

Projeye güveniyorsanız:

**Trust Workspace & Continue**

seçeneğine basın.

---

### 6. Proje Paketlerini Yükleyin

VS Code içerisinde:

**Terminal → New Terminal**

seçeneğini açın.

Terminalde proje klasöründe olduğunuzdan emin olun ve:

```bash
dotnet restore
```

komutunu çalıştırın.

Bu işlem projede kullanılan NuGet paketlerini yükler.

---

### 7. Projeyi Çalıştırın

Restore işlemi tamamlandıktan sonra:

```bash
dotnet run
```

komutunu çalıştırın.

Alternatif olarak geliştirme ortamınız doğru yapılandırılmışsa:

**F5**

tuşuna basarak da projeyi çalıştırabilirsiniz.

---

##  Visual Studio Kullanıyorsanız

Projeyi Visual Studio ile çalıştırmak için ZIP dosyasını yine önce ayıklayın.

Ardından ayıklanan klasör içerisindeki:

```text
FiloYenile.csproj
```

dosyasına çift tıklayabilirsiniz.

Visual Studio projeyi yükledikten sonra NuGet paketlerinin geri yüklenmesini bekleyin.

Daha sonra:

**F5**

veya üst bölümdeki:

** Start**

butonuyla uygulamayı çalıştırabilirsiniz.

---

## Gereksinimler

* Windows işletim sistemi
* .NET 10 SDK
* Visual Studio veya Visual Studio Code
* VS Code kullanılıyorsa C# geliştirme araçları
* İnternet bağlantısı (ilk NuGet paketlerinin indirilmesi için)

---

##  Sık Karşılaşılan Sorunlar

### `A compatible .NET SDK was not found`

Bilgisayarda projenin ihtiyaç duyduğu .NET SDK kurulu değildir.

**.NET 10 SDK yüklenmelidir.**

### `NO FOLDER OPENED`

Proje klasör olarak açılmamıştır.

**File → Open Folder**

seçeneği kullanılarak ayıklanan ana proje klasörü açılmalıdır.

### F5'e basıldığında proje başlamıyor

Öncelikle terminalden:

```bash
dotnet restore
```

ardından:

```bash
dotnet run
```

komutlarını deneyin.

### ZIP içerisinden proje çalışmıyor

ZIP dosyasına sağ tıklayıp:

**Tümünü Ayıkla**

seçeneğini kullanın ve projeyi oluşan normal klasör içerisinden açın.

