using Db_First;
using Labb2_DbFirst_Template.Entities;

namespace BookStore;

public static class AppContextManager
{

    public static BooksContext? Context { get; private set; }

    public static void Initialize(BooksContext context)
    {
        Context = context;
    }
}