# Profit Task
## REST API (Cilent)
***
> Task Front və Back ayrılıqda iki fərqli yolla yazılmışdır.
### Front
> **Pagination** və **Search** həm `Js`dən istifadə edərək yazilib həm də sorğuları `Controller`ə gödərək. Yazılıbdır.
 - `Use JavaScript` linkdən bu nəticəyə baxa bilərsiz.Burada `DataTable` istifadə etmişik.
 .`DataTable` bizə imkan tanıyır ki  `HTML`lə doldurlan datalar üzərində axdarış və səyfələmə işləri görək. [Qaynaq linki buradadır.](https://datatables.net/)
 - `Home(Use Back End)` burada isə sorğuları `Controller`ə gödərərək bizə lazim olan səyfələmə mənitiqinə və ya axtarışın nəticəsinə uyğun olan datanı əldə edirik. Burada mənim yazdığım bir `Extension`dan istifadə etdim.

 ### Back 
> `Back`i yazarkən iki fərqli yoldan istifadə etdim.Biri sadəcə `Entity Framework`dən istifadə edərək digəri isə `Repository Pattern`dən isitfadə edərək yazılmışdır.
- `version_ef` folderinin içərisindəki proyekt sadəcə `Entity Framework` istifadə edib.
- `version_repository_pattern` folderin içərsindəki proyekt həm `Entity Framework`dən həmdə `Repository Pattern`dən isitfadə edərək yazılmışdır.Belə kiçik tipli tapşırıqlarda sadəcə `ef` istifadə edir amma tapşırığın məqsədi mənim bilik və bacarıqlarımı ölçmək olduğu üçün xüsusən `Repository Pattern`lə yazmaq qərarına gəldim.

