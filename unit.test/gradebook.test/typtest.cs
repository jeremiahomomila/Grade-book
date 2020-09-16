using System;
using Xunit;

namespace src.test
{
    public delegate string WritelogDelegate(string logmessage);
    public class typetest
    {

          int count = 0;
           [Fact] 
            public void writelogDelegatecanpointtomethod()
            {
                WritelogDelegate log = Returnmessage;
                log += Returnmessage;
                log += incrementcount;
                log += ReturnMe;
              

                var result = log("hello!");
                Assert.Equal(4, count);
            }
             string ReturnMe(string message)
            {
                count++;
                return message.ToLower();
            }

             string incrementcount(string message)
            {
                count++;
                return message.ToUpper();
            }

            string Returnmessage(string message)
            {
                count++;
                return message;
            }
           [Fact]
           public void valuetypepassbyreference()
        {
            var x = GetInt();
            setInt(ref x);

           Assert.Equal(42, x);
        }

        private void setInt(ref Int32 z)
        {
              z = 42;
        }

        private int GetInt()
        {
           return 3;
        }

        [Fact]
        public void csharpcanpassbyref()
        {
            var book1 = Getbook("book 1");
            Getbooksetname(out book1, "new Name");      
         
            Assert.Equal("new Name", book1.Name);
        }

        private void Getbooksetname(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        
        }
          [Fact]
        public void csharppassbyvalue()
        {
            var book1 = Getbook("book 1");
            Getbooksetname(book1, "new Name");      
         
            Assert.Equal("book 1", book1.Name);
        }

        private void Getbooksetname(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        
        }

        [Fact]
        public void Cantsetnamefromreference()
        {
            var book1 = Getbook("book 1");
            setname(book1, "new Name");      
         
            Assert.Equal("new Name", book1.Name);
        }

        private void setname(InMemoryBook book, string name)
        {
           book.Name = name;
        }

        [Fact]
        public void stringsbehavelikevaluetype()
        {
            string name = "jeremiah";
           var upper = makeUppercase(name);

            Assert.Equal("jeremiah", name);
            Assert.Equal("JEREMIAH", upper);
        }

        private string makeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void Getbookreturnsdifferentobjects()
        {
            var book1 = Getbook("book 1");
            var book2 = Getbook("book 2");
         
            Assert.Equal("book 1", book1.Name);
            Assert.Equal("book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }
        [Fact]
        public void TwovarsCanReferenceSameObjects()
        {
            var book1 = Getbook("book 1");
            var book2 = book1;
         
            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }
        InMemoryBook Getbook(string name)
        {
            return new InMemoryBook(name); 
            
        }
    }

  
}
