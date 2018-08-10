using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace LibraryApi.Models
{
    public class Author : Identifiable
    {
        [Attr("first")] public string First { get; set; }
        [Attr("last")] public string Last { get; set; }

        [HasMany("books")] public List<Book> Books { get; set; }
    }
}
