﻿// Copyright 2009-2017 Josh Close and Contributors
// This file is a part of CsvHelper and is dual licensed under MS-PL and Apache 2.0.
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html for MS-PL and http://opensource.org/licenses/Apache-2.0 for Apache 2.0.
// https://github.com/JoshClose/CsvHelper
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CsvHelper.Configuration
{
	/// <summary>
	/// Sets type converter options on a property/field map.
	/// </summary>
    public class MapTypeConverterOption
    {
	    private readonly CsvPropertyMap propertyMap;

		/// <summary>
		/// Creates a new instance using the given <see cref="CsvPropertyMap"/>.
		/// </summary>
		/// <param name="propertyMap">The property/field map the options are being applied to.</param>
	    public MapTypeConverterOption( CsvPropertyMap propertyMap )
	    {
		    this.propertyMap = propertyMap;
	    }

		/// <summary>
		/// The <see cref="CultureInfo"/> used when type converting.
		/// This will override the global <see cref="CsvConfiguration.CultureInfo"/>
		/// setting.
		/// </summary>
		/// <param name="cultureInfo">The culture info.</param>
		public virtual CsvPropertyMap CultureInfo( CultureInfo cultureInfo )
		{
			propertyMap.Data.TypeConverterOptions.CultureInfo = cultureInfo;

			return propertyMap;
		}

		/// <summary>
		/// The <see cref="DateTimeStyles"/> to use when type converting.
		/// This is used when doing any <see cref="DateTime"/> conversions.
		/// </summary>
		/// <param name="dateTimeStyle">The date time style.</param>
		public virtual CsvPropertyMap DateTimeStyles( DateTimeStyles dateTimeStyle )
		{
			propertyMap.Data.TypeConverterOptions.DateTimeStyle = dateTimeStyle;

			return propertyMap;
		}

		/// <summary>
		/// The <see cref="NumberStyles"/> to use when type converting.
		/// This is used when doing any number conversions.
		/// </summary>
		/// <param name="numberStyle"></param>
		public virtual CsvPropertyMap NumberStyles( NumberStyles numberStyle )
		{
			propertyMap.Data.TypeConverterOptions.NumberStyle = numberStyle;

			return propertyMap;
		}

		/// <summary>
		/// The string format to be used when type converting.
		/// </summary>
		/// <param name="formats">The format.</param>
		public virtual CsvPropertyMap Format( params string[] formats )
		{
			propertyMap.Data.TypeConverterOptions.Formats = formats;

			return propertyMap;
		}

		/// <summary>
		/// The string values used to represent a boolean when converting.
		/// </summary>
		/// <param name="isTrue">A value indicating whether true values or false values are being set.</param>
		/// <param name="clearValues">A value indication if the current values should be cleared before adding the new ones.</param>
		/// <param name="booleanValues">The string boolean values.</param>
		public virtual CsvPropertyMap BooleanValues( bool isTrue, bool clearValues = true, params string[] booleanValues )
		{
			if( isTrue )
			{
				if( clearValues )
				{
					propertyMap.Data.TypeConverterOptions.BooleanTrueValues.Clear();
				}

				propertyMap.Data.TypeConverterOptions.BooleanTrueValues.AddRange( booleanValues );
			}
			else
			{
				if( clearValues )
				{
					propertyMap.Data.TypeConverterOptions.BooleanFalseValues.Clear();
				}

				propertyMap.Data.TypeConverterOptions.BooleanFalseValues.AddRange( booleanValues );
			}

			return propertyMap;
		}

		/// <summary>
		/// The string values used to represent null when converting.
		/// </summary>
		/// <param name="nullValues">The values that represent null.</param>
		/// <returns></returns>
		public virtual CsvPropertyMap NullValues( params string[] nullValues )
		{
			return NullValues( true, nullValues );
		}

		/// <summary>
		/// The string values used to represent null when converting.
		/// </summary>
		/// <param name="clearValues">A value indication if the current values should be cleared before adding the new ones.</param>
		/// <param name="nullValues">The values that represent null.</param>
		/// <returns></returns>
		public virtual CsvPropertyMap NullValues( bool clearValues, params string[] nullValues )
		{
			if( clearValues )
			{
				propertyMap.Data.TypeConverterOptions.NullValues.Clear();
			}

			propertyMap.Data.TypeConverterOptions.NullValues.AddRange( nullValues );

			return propertyMap;
		}
	}
}
