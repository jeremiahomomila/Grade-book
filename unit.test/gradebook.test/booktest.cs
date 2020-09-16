using System;
using Xunit;

namespace src.test
{
    public class booktest
    {
        [Fact]
        public void bookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook(""); 
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
        

            //act
            var result = book.Getstat();

            //assert
            
            Assert.Equal(85.6, result.average, 1);
            Assert.Equal(90.5, result.high, 1);
            Assert.Equal(77.3, result.low, 1);
            Assert.Equal('B', result.letter);
            

        }
    }

  
}
