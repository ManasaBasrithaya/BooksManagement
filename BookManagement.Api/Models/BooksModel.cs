using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Api.Model
{
    public class BooksModel
    {
        private int id;
        private string name;
        private string authorName;

        public int Id
        {
            get
            {
               return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string AuthorName
        {
            get
            {
                return this.authorName;
            }
            set
            {
                this.authorName = value;
            }
        }
    }
}
