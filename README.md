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

#  Filo Yenileme Karar Destek Sistemi

Projeyi GitHub üzerinden indirdikten sonra aşağıdaki adımları takip ederek uygulamayı **Visual Studio Code** üzerinden çalıştırabilirsiniz.

##  1. Projeyi İndirin

GitHub sayfasında:

**Code → Download ZIP**

seçeneğini kullanarak projeyi bilgisayarınıza indirin.

>  Önemli: ZIP dosyasının içerisinden projeyi doğrudan çalıştırmayın.

İndirdiğiniz ZIP dosyasına sağ tıklayın ve:

**Tümünü Ayıkla / Extract All**

seçeneğiyle projeyi bir klasöre çıkarın.

---

##  2. Visual Studio Code ile Açın

**Visual Studio Code** uygulamasını açın.

Ardından:

**File → Open Folder**

seçeneğine tıklayın.

Ayıkladığınız **FiloYenile-main** klasörünü seçin.

Sol taraftaki **Explorer** bölümünde proje dosyaları görünmelidir.

Özellikle:

```text
FiloYenile.csproj
App.xaml
MainWindow.xaml
```

dosyalarını görebildiğinizden emin olun.

---

##  3. Restricted Mode Uyarısı Çıkarsa

VS Code projeyi ilk kez açarken:

**Restricted Mode**

uyarısı gösterebilir.

Bu durumda:

**Manage → Trust**

veya

**Trust this folder**

seçeneğini kullanın.

Proje dosyaları bundan sonra normal şekilde kullanılabilir.

---

##  4. Terminali Açın

VS Code üst menüsünden:

**Terminal → New Terminal**

seçeneğine tıklayın.

Alternatif olarak:

```text
Ctrl + `
```

kısayolunu kullanabilirsiniz.

---

##  5. Terminalin Doğru Klasörde Olduğunu Kontrol Edin

Terminale:

```powershell
dir
```

yazın ve **Enter** tuşuna basın.

Çıkan dosyaların arasında:

```text
FiloYenile.csproj
```

görünüyorsa doğru klasördesiniz.

### FiloYenile.csproj görünmüyorsa

Örneğin terminal bir üst klasördeyse:

```powershell
cd FiloYenile-main
```

yazıp **Enter** tuşuna basın.

Ardından tekrar:

```powershell
dir
```

yazın.

`FiloYenile.csproj` görünene kadar proje klasöründe olduğunuzdan emin olun.

> Not: Explorer'da `FiloYenile.csproj` dosyasına tıklamak terminalin bulunduğu klasörü değiştirmez. Terminalin de proje klasöründe olması gerekir.

---

##  6. .NET Kurulumunu Kontrol Edin

Terminale:

```powershell
dotnet --version
```

yazın.

Bir sürüm numarası görüntüleniyorsa .NET SDK bilgisayarınız tarafından tanınıyor demektir.

Örneğin:

```text
10.0.300
```

Proje **.NET 10** hedeflemektedir. Bu nedenle uygun .NET SDK'nın bilgisayarınızda kurulu olması gerekir.

---

##  7. Projeyi Derleyin

Terminale:

```powershell
dotnet build
```

yazıp **Enter** tuşuna basın.

İşlem başarılıysa terminalde buna benzer bir sonuç göreceksiniz:

```text
Build succeeded.
0 Error(s)
```

Bu mesaj, projenin başarıyla derlendiğini gösterir.

---

##  8. Uygulamayı Çalıştırın

Build işlemi başarılı olduktan sonra:

```powershell
dotnet run
```

yazıp **Enter** tuşuna basın.

Birkaç saniye içerisinde **Filo Yenileme Karar Destek Sistemi** açılacaktır.

---

##  Sık Karşılaşılan Hata

Eğer:

> Bir proje veya çözüm dosyası belirtin. Geçerli çalışma dizini bir proje veya çözüm dosyası içermiyor.

benzeri bir hata alırsanız terminal yanlış klasörde bulunmaktadır.

Şunu çalıştırın:

```powershell
dir
```

Listede:

```text
FiloYenile.csproj
```

bulunmalıdır.

Bulunmuyorsa proje klasörüne geçin:

```powershell
cd FiloYenile-main
```

Ardından:

```powershell
dotnet build
```

ve başarılı olduktan sonra:

```powershell
dotnet run
```

komutlarını çalıştırın.

---

## Kısa Kurulum Özeti


GitHub → Code → Download ZIP
            ↓
        ZIP'i Ayıkla
            ↓
      VS Code'u Aç
            ↓
     File → Open Folder
            ↓
     FiloYenile-main
            ↓
 Restricted Mode varsa Trust
            ↓
    Terminal → New Terminal
            ↓
           dir
            ↓
 FiloYenile.csproj görünüyor mu?
            ↓
     dotnet --version
            ↓
       dotnet build
            ↓
      Build succeeded
            ↓
        dotnet run
            ↓
       Uygulama Açılır


