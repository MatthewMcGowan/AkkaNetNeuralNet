﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Util.Internal;
using AkkaNetNeuralNet.Core.Model;
using AkkaNetNeuralNet.Core.Normalisation;
using NUnit.Framework;

namespace AkkaNetNerualNet.Core.Test.Normalisation
{
    [TestFixture]
    public class AgeAtDeathNormalisationTests
    {
        private IEnumerable<DogProfile> _data;

        [SetUp]
        public void SetUp()
        {
            _data = SetUpData();
        }

        [Test]
        public void NormaliseAges_ReturnsSameNumberOfInputRecords()
        {
            var result = _data.NormaliseAges();

            Assert.AreEqual(_data.Count(), result.Count());
        }

        [Test]
        public void NormaliseAges_ReturnsOtherFieldsUnmodified()
        {
            var result = _data.NormaliseAges();

            bool OtherFieldEquality(DogProfile x, DogProfile y) =>
                x.Sex == y.Sex &&
                x.AdultBodymass == y.AdultBodymass &&
                x.HouseholdIncome == y.HouseholdIncome &&
                x.Locale == y.Locale;

            Assert.IsTrue(_data.All(d => result.Any(r => OtherFieldEquality(d, r))));
        }

        [Test]
        public void NormaliseAges_MinCorrectlyNormalised()
        {
            decimal minAge = _data.NormaliseAges().ToList()[0].AgeAtDeath;

            Assert.AreEqual(0, minAge);
        }

        [Test]
        public void NormaliseAges_MaxCorrectlyNormalised()
        {
            decimal maxAge = _data.NormaliseAges().ToList()[2].AgeAtDeath;

            Assert.AreEqual(1, maxAge);
        }

        [Test]
        public void NormaliseAges_IntermediateCorrectlyNormalised()
        {
            decimal age = _data.NormaliseAges().ToList()[1].AgeAtDeath;

            Assert.AreEqual(0.25, age);
        }

        private IEnumerable<DogProfile> SetUpData()
        {
            return new List<DogProfile>
            {
                new DogProfile {AgeAtDeath = 2, Sex = Sex.Male, AdultBodymass = 2, HouseholdIncome = 2, Locale = Locale.Rural},
                new DogProfile {AgeAtDeath = 4, Sex = Sex.Male, AdultBodymass = 4, HouseholdIncome = 4, Locale = Locale.Suburban},
                new DogProfile {AgeAtDeath = 10, Sex = Sex.Female, AdultBodymass = 10, HouseholdIncome = 10, Locale = Locale.Urban},
            };
        }
    }
}
