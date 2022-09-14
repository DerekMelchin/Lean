/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Python.Runtime;
using QuantConnect.Algorithm;
using QuantConnect.Algorithm.Framework.Selection;
using QuantConnect.Data.UniverseSelection;
using QuantConnect.Python;

namespace QuantConnect.Tests.Algorithm.Framework.Selection
{
    [TestFixture]
    public class ETFConstituentsUniverseSelectionModelTests
    {
        [Test]
        [TestCase("Test_ETFConstituentsUniverseSelectionModel_Python", "<class 'QuantConnect.Algorithm.Framework.Selection.ETFConstituentsUniverseSelectionModel'>")]
        [TestCase("Test_ETFConstituentsUniverseSelectionModel_CSharp", "<<class 'QuantConnect.Algorithm.Framework.Selection.ETFConstituentsUniverseSelectionModel'>>")]
        public void TestPythonAndCSharpImports(string moduleName, string expected)
        {
            PythonInitializer.Initialize();
            using (Py.GIL())
            {
                var module = Py.Import(moduleName);
                dynamic algorithm = module.GetAttr("ETFConstituentsFrameworkAlgorithm").Invoke();
                algorithm.Initialize();
                Assert.AreEqual(algorithm.universe_type, expected);
            }
        }
    }
}
