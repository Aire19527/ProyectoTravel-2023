using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Domain.DTO.Library.Book
{
    public class Book_Dto : AddBook_Dto
    {
        public int Id { get; set; }
    }
}
