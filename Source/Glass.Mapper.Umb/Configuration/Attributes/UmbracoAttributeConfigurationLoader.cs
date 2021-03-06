/*
   Copyright 2012 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/ 
//-CRE-

using System.Linq;
using Glass.Mapper.Configuration;
using Glass.Mapper.Configuration.Attributes;

namespace Glass.Mapper.Umb.Configuration.Attributes
{
    /// <summary>
    /// UmbracoAttributeConfigurationLoader
    /// </summary>
    public class UmbracoAttributeConfigurationLoader : AttributeConfigurationLoader<UmbracoTypeConfiguration, UmbracoPropertyConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoAttributeConfigurationLoader"/> class.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        public UmbracoAttributeConfigurationLoader(params string[] assemblies)
            : base(assemblies)
        {

        }

        /// <summary>
        /// Configs the created.
        /// </summary>
        /// <param name="config">The config.</param>
        protected override void ConfigCreated(AbstractTypeConfiguration config)
        {
            var umbConfig = config as UmbracoTypeConfiguration;

	        if (umbConfig != null)
	        {
		        //find the property configs that will be used to link a umbraco item to a class
		        umbConfig.IdConfig =
			        config.Properties.FirstOrDefault(x => x is UmbracoIdConfiguration) as UmbracoIdConfiguration;

		        var umbInfos = config.Properties.Where(x => x is UmbracoInfoConfiguration).Cast<UmbracoInfoConfiguration>();
		        umbConfig.VersionConfig = umbInfos.FirstOrDefault(x => x.Type == UmbracoInfoType.Version);
	        }

	        base.ConfigCreated(config);
        }
    }
}



