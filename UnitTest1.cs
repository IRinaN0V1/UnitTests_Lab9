using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Лаба9;

namespace TestCarParking
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            CarParking cp = new CarParking();

            Assert.AreEqual(new CarParking(1, 0), cp);
        }//Конструктор по умолчанию для объекта класса CarParking

        [TestMethod]
        public void TestNumSlots()
        {
            CarParking cp = new CarParking(0, 2);

            Assert.AreEqual(new CarParking(1, 1), cp);
        }//Неправильный ввод количества мест на парковке

        [TestMethod]
        public void TestNumCars()
        {
            CarParking cp = new CarParking(2, -1);

            Assert.AreEqual(new CarParking(2, 0), cp);
        }//Неправильный ввод количества машин на парковке

        [TestMethod]
        public void TestExcessOfCarsOverSlots()
        {
            CarParking cp = new CarParking(2, 3);

            Assert.AreEqual(new CarParking(2, 2), cp);
        }//Превышение кол-ва машин над кол-вом мест

        [TestMethod]
        public void TestParamConstructor_Decrement()
        {
            CarParking cp = new CarParking(5, 2);
            --cp;

            Assert.AreEqual(new CarParking(5, 1), cp);
        }//Конструктор с параметром и декремент для объекта класса CarParking

        [TestMethod]
        public void TestIncrement()
        {
            CarParking cp = new CarParking();
            ++cp;

            Assert.AreEqual(new CarParking(1, 1), cp);
        }//Инкремент для объекта класса CarParking

        [TestMethod]
        public void TestCopyConstructor()
        {
            CarParking cp = new CarParking(6,3);

            Assert.AreEqual(new CarParking(cp), cp);
        }//Конструктор копирования для класса CarParking

        [TestMethod]
        public void TestComparisonOperations()
        {
            CarParking cp1 = new CarParking(10,2);
            CarParking cp2 = new CarParking(3,1);

            Assert.AreEqual(true, cp1 > cp2);
            Assert.AreEqual(false, cp1 < cp2);
        }//Перегруженные операции сравнеия двух объектов класса CarParking

        [TestMethod]
        public void TestSumOperation_ObjectCount()
        {
            CarParking cp1 = new CarParking(4, 1);
            CarParking cp2 = new CarParking(5, 4);

            Assert.AreEqual(new CarParking(9, 5), cp1 + cp2);
        }//Перегруженные операция сложения двух объектов класса CarParking

        [TestMethod]
        public void TestObjectCount()
        {
            int numObj = CarParking.ObjectCount();
            CarParking cp1 = new CarParking(0, 1);
            CarParking cp2 = new CarParking(2, 4);

            Assert.AreEqual(numObj + 2, CarParking.ObjectCount());
        }//Подсчет объектов класса CarParking

        [TestMethod]
        public void TestExplicitConversion()
        {
            CarParking carParking = new CarParking(10, 0);
            int missingCars = (int)carParking;
            Assert.AreEqual(8, missingCars);
        }//Операция явного преобразования типа double к типу int

        [TestMethod]
        public void TestImplicitConversion()
        {
            CarParking cp = new CarParking(5, 2);
            Assert.AreEqual(true, (bool)cp);
        }//Операция не явного преобразования к типу bool


        [TestMethod]
        public void TestParkingOccupancy()
        {
            CarParking cp = new CarParking(15, 7);
            Assert.AreEqual(46.67, CarParking.ParkingOccupancy(cp.NumSlots, cp.NumCars));
        }//Статический метод, вычисляющий заполненность парковки

        [TestMethod]
        public void TestDefaultCostructorOfCollection()
        {
            CarParkingArray p = new CarParkingArray();
            Assert.AreEqual(new CarParking(1, 0), p[0]);
        }//Конструктор по умолчанию для коллекции класса CarParking

        [TestMethod]
        public void TestCopyCostructorOfCollection()
        {
            CarParkingArray p1 = new CarParkingArray();
            CarParkingArray p2 = new CarParkingArray(p1);
            Assert.AreEqual(p2[0], p1[0]);
        }//Конструктор по умолчанию для коллекции класса CarParkingArray

        [TestMethod]
        public void TestGet()
        {
            CarParkingArray p = new CarParkingArray(5);
            Assert.ThrowsException<Exception>(() => { new CarParking(p[10]); });
        }

        [TestMethod]
        public void TestSet()
        {
            CarParkingArray p = new CarParkingArray(5);
            p[3] = new CarParking(2, 1);
            Assert.AreEqual(new CarParking(2,1), p[3]);
        }

        [TestMethod]
        public void TestCount()
        {
            int сount = CarParkingArray.Count();

            CarParkingArray p1 = new CarParkingArray();
            CarParkingArray p2 = new CarParkingArray(3);

            Assert.AreEqual(сount + 2, CarParkingArray.Count());
        }
    }
}

