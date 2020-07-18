using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FishTankChallenge.UnitTests
{
    public class FishTankTests
    {
        private FishTank tank;

        [SetUp]
        public void Setup()
        {
            tank = new FishTank();
        }

        [Test]
        public void BiggerCrabsShouldEatSmallerOnes()
        {
            var crab1 = new Crab { Name = "Alfonz", Size = Animal.AnimalSize.Big };
            var crab2 = new Crab { Name = "Billy", Size = Animal.AnimalSize.Small };

            tank.AddAnimal(crab1);
            tank.AddAnimal(crab2);

            tank.StartGameofLife();

            var expected = new List<Animal>
            {
                new Crab
                {
                    Name = crab1.Name,
                    Size = crab1.Size,
                    IsDead = false
                },
                new Crab
                {
                    Name = crab2.Name,
                    Size = crab2.Size,
                    IsDead = true
                }
            };
            tank.Animals.Should().Equal(expected);
        }

        [Test]
        public void HiddenCrabsShouldNotEatOthers()
        {
            var crab1 = new Crab { Name = "Alfonz", Size = Animal.AnimalSize.Big, IsHidden = true };
            var crab2 = new Crab { Name = "Billy", Size = Animal.AnimalSize.Small };

            tank.AddAnimal(crab1);
            tank.AddAnimal(crab2);

            tank.StartGameofLife();

            var expected = new List<Animal>
            {
                new Crab
                {
                    Name = crab1.Name,
                    Size = crab1.Size,
                    IsDead = false,
                    IsHidden = true
                },
                new Crab
                {
                    Name = crab2.Name,
                    Size = crab2.Size,
                    IsDead = false
                }
            };
            tank.Animals.Should().Equal(expected);
        }

        [Test]
        [TestCase(Animal.AnimalSize.Small, true)]
        [TestCase(Animal.AnimalSize.Medium, false)]
        [TestCase(Animal.AnimalSize.Big, false)]
        public void FishesEatOnlySmallCrabs(Animal.AnimalSize crabSize, bool isDead)
        {
            var fish = new Fish { Name = "Alfonz", Size = Animal.AnimalSize.Big };
            var crab = new Crab { Name = "Billy", Size = crabSize };

            tank.AddAnimal(fish);
            tank.AddAnimal(crab);

            tank.StartGameofLife();

            var expected = new List<Animal>
            {
                new Fish
                {
                    Name = fish.Name,
                    Size = fish.Size,
                    IsDead = false
                },
                new Crab
                {
                    Name = crab.Name,
                    Size = crab.Size,
                    IsDead = isDead
                }
            };
            tank.Animals.Should().Equal(expected);
        }

        [Test]
        [TestCase(Animal.AnimalSize.Big, Animal.AnimalSize.Medium, true)]
        [TestCase(Animal.AnimalSize.Medium, Animal.AnimalSize.Small, true)]
        [TestCase(Animal.AnimalSize.Small, Animal.AnimalSize.Small, false)]
        public void FishesOnlyEatExactlyOneSizeSmallerFishes(Animal.AnimalSize fishSize1, Animal.AnimalSize fishSize2, bool isDead)
        {
            var fish1 = new Fish { Name = "Alfonz", Size = fishSize1 };
            var fish2 = new Fish { Name = "Billy", Size = fishSize2 };

            tank.AddAnimal(fish1);
            tank.AddAnimal(fish2);

            tank.StartGameofLife();

            var expected = new List<Animal>
            {
                new Fish
                {
                    Name = fish1.Name,
                    Size = fish1.Size,
                    IsDead = false
                },
                new Fish
                {
                    Name = fish2.Name,
                    Size = fish2.Size,
                    IsDead = isDead
                }
            };
            tank.Animals.Should().Equal(expected);
        }
    }
}