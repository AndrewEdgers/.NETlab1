using System.Collections;
using NETLab1;

namespace FlexibleTest
{
    public class FlexibleDequeTests
    {
        // Тест на додавання елементу в кінець деку
        [Fact]
        public void EnqueueTail_ShouldAddItemToEnd()
        {
            var deque = new FlexibleDeque<string>();
            deque.EnqueueTail("test");

            Assert.Equal("test", deque.DequeueTail());
        }

        // Тест на додавання елементу в початок деку
        [Fact]
        public void EnqueueHead_ShouldAddItemToStart()
        {
            var deque = new FlexibleDeque<string>();
            deque.EnqueueHead("test");

            Assert.Equal("test", deque.DequeueHead());
        }

        // Тест на видалення елементу з початку деку
        [Fact]
        public void DequeueHead_ShouldRemoveItemFromStart()
        {
            var deque = new FlexibleDeque<string>();
            deque.EnqueueHead("test");

            Assert.Equal("test", deque.DequeueHead());
        }

        // Тест на видалення елементу з кінця деку
        [Fact]
        public void DequeueTail_ShouldRemoveItemFromEnd()
        {
            var deque = new FlexibleDeque<string>();
            deque.EnqueueTail("test");

            Assert.Equal("test", deque.DequeueTail());
        }

        // Тест на видалення елементу з кінця порожнього деку
        [Fact]
        public void DequeueTail_OnEmpty_ShouldThrow()
        {
            var deque = new FlexibleDeque<object>();

            Assert.Throws<InvalidOperationException>(() => deque.DequeueTail());
        }

        // Тест на перевірку, що новий дек є порожнім
        [Fact]
        public void IsEmpty_ShouldBeTrueForNewDeque()
        {
            var deque = new FlexibleDeque<object>();

            Assert.True(deque.IsEmpty);
        }

        // Тест на очищення деку
        [Fact]
        public void Clear_ShouldEmptyDeque()
        {
            var deque = new FlexibleDeque<int>();
            deque.EnqueueHead(10);
            deque.Clear();

            Assert.True(deque.IsEmpty);
        }

        // Тест на пошук елементу в деку
        [Fact]
        public void Contains_ShouldFindItem()
        {
            var deque = new FlexibleDeque<string>();
            deque.EnqueueTail("test");

            Assert.True(deque.Contains("test"));
        }

        // Тест на ітерацію по всім елементам деку
        [Fact]
        public void GetEnumerator_ShouldAllowIterationOverDeque()
        {
            var deque = new FlexibleDeque<int>();
            deque.EnqueueTail(1);
            deque.EnqueueTail(2);
            deque.EnqueueTail(3);

            int sum = 0;
            foreach (var item in deque)
            {
                sum += item;
            }

            Assert.Equal(6, sum);
        }

        // Комбінований тест на перевірку кількох операцій
        [Fact]
        public void CombinedOperations_ShouldProcessCorrectly()
        {
            var deque = new FlexibleDeque<int>();
            deque.EnqueueHead(1);
            deque.EnqueueTail(2);
            deque.EnqueueHead(3);

            Assert.Equal(3, deque.DequeueHead());
            Assert.Equal(1, deque.DequeueHead());
            Assert.Equal(2, deque.DequeueTail());
            Assert.True(deque.IsEmpty);
        }

        // Тест на додавання та видалення null
        [Fact]
        public void EnqueueNull_ShouldThrowOrHandle()
        {
            var deque = new FlexibleDeque<string?>();

            deque.EnqueueTail(null);
            Assert.Null(deque.DequeueTail());
        }

        // Тест на додавання багатьох елементів
        [Fact]
        public void EnqueueMultipleItems_ShouldIncreaseCount()
        {
            var deque = new FlexibleDeque<int>();
            for (int i = 0; i < 100; i++)
            {
                deque.EnqueueTail(i);
            }

            Assert.Equal(100, deque.Count);
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i, deque.DequeueHead());
            }
        }

        // Тест перевіряє, що спроба видалити елемент з порожнього деку викликає виключення
        [Fact]
        public void DequeueHead_WhenDequeIsEmpty_ShouldThrow()
        {
            var deque = new FlexibleDeque<int>();
            Assert.Throws<InvalidOperationException>(() => deque.DequeueHead());
        }

        // Тест перевіряє, що кількість елементів після додавання відповідає очікуваній
        [Fact]
        public void Count_AfterEnqueuing_ShouldReturnCorrectCount()
        {
            var deque = new FlexibleDeque<int>();
            deque.EnqueueHead(1);
            deque.EnqueueHead(2);
            Assert.Equal(2, deque.Count);
        }

        // Тест перевіряє, що метод Contains повертає false для елементу, який не присутній у деку
        [Fact]
        public void Contains_WhenItemNotPresent_ShouldReturnFalse()
        {
            var deque = new FlexibleDeque<string>();
            deque.EnqueueTail("test");
            Assert.False(deque.Contains("not-present"));
        }

        // Тест перевіряє, що можна ітерувати по деку використовуючи неузагальнений IEnumerator
        [Fact]
        public void GetEnumerator_NonGeneric_ShouldIterateOverDeque()
        {
            var deque = new FlexibleDeque<int>();
            deque.EnqueueTail(1);
            deque.EnqueueTail(2);
            deque.EnqueueTail(3);

            int sum = 0;
            foreach (object obj in (IEnumerable)deque)
            {
                sum += (int)obj;
            }

            Assert.Equal(6, sum);
        }
    }
}