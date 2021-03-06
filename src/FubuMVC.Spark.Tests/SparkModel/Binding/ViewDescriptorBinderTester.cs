﻿using FubuMVC.Spark.SparkModel;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Spark.Tests.SparkModel.Binding
{
    public class ViewDescriptorBinderTester : InteractionContext<ViewDescriptorBinder>
    {
        [Test]
        public void does_not_bind_partials()
        {
            var request = new BindRequest
            {
                Target = new Template("_partial.spark", "", "testing")
            };

            ClassUnderTest.CanBind(request).ShouldBeFalse();
        }

        [Test]
        public void does_not_bind_files_other_than_spark()
        {
            var request = new BindRequest
            {
                Target = new Template("_partial.html", "", "testing")
            };

            ClassUnderTest.CanBind(request).ShouldBeFalse();
        }

        [Test]
        public void if_template_is_valid_for_binding_then_binder_can_be_applied()
        {
            var request = new BindRequest
            {
                Target = new Template("Fubu.spark", "", "testing"),
            };

            ClassUnderTest.CanBind(request).ShouldBeTrue();
        }

        [Test]
        public void assign_descriptor_as_an_instance_of_viewdescriptor()
        {
            var request = new BindRequest
            {
                Target = new Template("Fubu.spark", "", "testing"),
            };

            ClassUnderTest.Bind(request);
            request.Target.Descriptor.ShouldBeOfType<ViewDescriptor>();
        }
    }
}
