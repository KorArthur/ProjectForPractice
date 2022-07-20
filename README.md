Название продукта: Сервис генерации числового пароля ProjectPass2. Сервис выполняет функции для генерации числового пароля, хеша и соли по входным данным. Предназначен для улучшения более крупного проекта или для использования в качестве отдельной модели. Сервис написан на языке C#, целевая платформа .NET 6.0., для запуска необходимо скачать visual studio 2022 после запустить проект через файл exe или sln. 
Информация для пользования: Сервис через API получает числовой код длинной 4-8 символов(кратно 2-м), соль и хеш. Длинна пароля и хеш передается через параметры запроса. Для получения данных необходимо запустить проект и ввести https://localhost:44342/Generic?ls=4&lp=6 где после слова Generic вводятся данные ls- это длинна соли, а lp - длинна пароля. После этого выводится наш сгененрированный пароль хеш и соль, которые можно использовать в других проектах. Запрос и ответ передавется в формате JSON. Для реализации документации использован Swagger. Для его отображения необходимо выполнить команду в браузере https://localhost:44342/swagger после чего появится окно с комментариями. В самой программе реализованны некоторые классы: class Optimal - отвечает за возврат и установку новых значений пароля,соли и хеша; class ClassPHS - отвечает за генерацию пароля, соли и хеша, а так же выполняющий проверку правильности введенных данных и их корректировку; так же есть класс Контроллера необходимый для передачи значений ls и lp.
