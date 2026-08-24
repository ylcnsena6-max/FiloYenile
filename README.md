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
