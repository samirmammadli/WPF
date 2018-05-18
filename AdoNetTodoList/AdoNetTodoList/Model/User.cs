using GalaSoft.MvvmLight;
using System;

namespace AdoNetTodoList.Model
{
    class User : ObservableObject
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { Set(ref firstName, value); }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { Set(ref surname, value); }
        }

        private DateTime regDate;
        public DateTime RegDate
        {
            get { return regDate; }
            set { Set(ref regDate, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { Set(ref email, value); }
        }
    }
}
