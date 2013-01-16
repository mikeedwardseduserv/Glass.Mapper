﻿using System;
using Glass.Mapper.Umb.Configuration;

namespace Glass.Mapper.Umb.DataMappers
{
    public class UmbracoParentMapper :AbstractDataMapper
    {
        public UmbracoParentMapper()
        {
            ReadOnly = true;
        }

        public override void MapToCms(AbstractDataMappingContext mappingContext)
        {
            throw new NotSupportedException();
        }

        public override object MapToProperty(AbstractDataMappingContext mappingContext)
        {
            var umbContext = mappingContext as UmbracoDataMappingContext;
            var umbConfig = Configuration as UmbracoParentConfiguration;

            return umbContext.Service.CreateClass(
                umbConfig.PropertyInfo.PropertyType,
                umbContext.Node.Parent,
                umbConfig.IsLazy,
                umbConfig.InferType);
        }

        public override bool CanHandle(Mapper.Configuration.AbstractPropertyConfiguration configuration, Context context)
        {
            return configuration is UmbracoParentConfiguration;
        }
    }
}