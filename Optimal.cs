namespace ProjectPass2
{
    // Класс возврщающий значения пароля,соли и хеша
    public class Optimal
    {
        private string password1;

        // возвращаем значение свойства пароль
        public string Getpassword()
        {
            return password1;
        }
        // устанавливаем новое значение свойства пароль
        public void Setpassword(string value)
        {
            password1 = value;
        }

        private string salt1;
        // возвращаем значение свойства соли
        public string Getsalt()
        {
            return salt1;
        }
        // устанавливаем новое значение свойства соли
        public void Setsalt(string value)
        {
            salt1 = value;
        }

        private string hash1;
        // возвращаем значение свойства хеш
        public string Gethash()
        {
            return hash1;
        }
        // устанавливаем новое значение свойства хеш
        public void Sethash(string value)
        {
            hash1 = value;
        }
    }
}
