using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Domain.DTO.Library.Book
{
    public class ConsultBook_Dto : Book_Dto
    {
        public string Editorial { get; set; }
        public string Autor { get; set; }
    }
}
