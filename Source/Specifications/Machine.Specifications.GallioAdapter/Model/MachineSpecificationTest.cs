using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallio.Model;
using Gallio.Model.Execution;
using Gallio.Reflection;
using Machine.Specifications.GallioAdapter.Services;
using Machine.Specifications.Model;

namespace Machine.Specifications.GallioAdapter.Model
{
  public class MachineSpecificationTest : MachineTest
  {
    private readonly Specification _specification;

    /*
    public Specification Specification
    {
      get { return _specification; }
    }
    */

    public MachineSpecificationTest(Specification specification) : base(specification.Name, Reflector.Wrap(specification.SpecificationField))
    {
      this.Kind = TestKinds.Test;
      this.IsTestCase = true;
      _specification = specification;
    }

    public SpecificationVerificationResult Execute()
    {
      MachineDescriptionTest parent = this.Parent as MachineDescriptionTest;
      if (parent == null) throw new Exception("Specification has non-Context parent???");

      var result = parent.Context.VerifySpecification(_specification);
      return result;
    }
  }
}
