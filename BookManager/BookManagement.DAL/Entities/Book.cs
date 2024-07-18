using System;
using System.Collections.Generic;

namespace BookManagement.DAL.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime PublicationDate { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string Author { get; set; } = null!;

    public int BookCategoryId { get; set; }

    public virtual BookCategory BookCategory { get; set; } = null!;
    // vietsub                  bien object tro vao table/ class BookCategory ben tay trai
    //             class/table
    //             Category (chua cate id ma cuon sach thuoc ve)
    //                                   chua ca GenerType, Desc
    //                             Bien nay dc goi la navigation patch
    //                       nho bien nay giup ta join bang moc sang table Category/class
    // dua ten bien vao trong cau join khi so table Book, so List<Book> Books trong DbContext
}
