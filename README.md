# Profit Task
## REST API (Cilent)
***
> Task Front və Back ayrılıqda iki fərqli yolla yazılmışdır.
### Front
> **Pagination** və **Search** həm `Js`dən istifadə edərək yazilib həm də sorğuları `Controller`ə gödərək. Yazılıbdır.
 - `Use JavaScript` linkdən bu nəticəyə baxa bilərsiz.Burada `DataTable` istifadə etmişik.`DataTable` bizə imkan tanıyır ki  `HTML`lə doldurlan datalar üzərində axdarış və səyfələmə işləri görək. [Qaynaq linki buradadır.](https://datatables.net/)
 [![useJs.png](https://i.postimg.cc/k45qmnVZ/useJs.png)](https://postimg.cc/bG4K0f9H)
 - `Home(Use Back End)` burada isə sorğuları `Controller`ə gödərərək bizə lazim olan səyfələmə mənitiqinə və ya axtarışın nəticəsinə uyğun olan datanı əldə edirik. Burada mənim yazdığım bir `Extension`dan istifadə etdim.
[![Untitled.png](https://i.postimg.cc/BQPZbQhf/Untitled.png)](https://postimg.cc/hfgR3gW2)
- `Data Seed``click`ləndiyi anda `api`dan dataları çəkib `database`ə save edir.Əgər databasedə data varsa error mesaji göstərir.
 ### Back 
> `Back`i yazarkən iki fərqli yoldan istifadə etdim.Biri sadəcə `Entity Framework`dən istifadə edərək digəri isə `Repository Pattern`dən isitfadə edərək yazılmışdır.

- `version_ef` folderinin içərisindəki proyekt sadəcə `Entity Framework` istifadə edib.
[![efpro.png](https://i.postimg.cc/mDjPjm4r/efpro.png)](https://postimg.cc/R63CVQNr)
- `version_repository_pattern` folderin içərsindəki proyekt həm `Entity Framework`dən həmdə `Repository Pattern`dən isitfadə edərək yazılmışdır.Belə kiçik tipli tapşırıqlarda sadəcə `ef` istifadə edir amma tapşırığın məqsədi mənim bilik və bacarıqlarımı ölçmək olduğu üçün xüsusən `Repository Pattern`lə yazmaq qərarına gəldim.
[![repositor.png](https://i.postimg.cc/cCJrbf1B/repositor.png)](https://postimg.cc/1nLmgnq8)
