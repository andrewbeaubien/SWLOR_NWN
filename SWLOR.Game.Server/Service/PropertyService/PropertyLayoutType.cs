﻿using System;

namespace SWLOR.Game.Server.Service.PropertyService
{
    public enum PropertyLayoutType
    {
        [PropertyLayoutType(
            PropertyType.Invalid,
            "Invalid", 
            0,
            999999,
            999999,
            "", 
            false)]
        Invalid = 0,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Small Apartment - Style 1",
            30, 
            5000, 
            200,
            "apartment_002", 
            true)]
        ApartmentSmallStyle1 = 1,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Small Apartment - Style 2", 
            30, 
            5000, 
            200,
            "playerap_s_unf", 
            true)]
        ApartmentSmallStyle2 = 2,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Small Apartment - Style 2 (Furnished)",
            15, 
            7000,
            300,
            "playerap_s_fur", 
            true)]
        ApartmentSmallStyle2Furnished = 3,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Medium Apartment - Style 1",
            50, 
            10000, 
            300,
            "apartment_2", 
            true)]
        ApartmentMediumStyle1 = 4,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Medium Apartment - Style 2", 
            50, 
            10000, 
            300,
            "playerap_m_unf", 
            true)]
        ApartmentMediumStyle2 = 5,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Medium Apartment - Style 2 (Furnished)", 
            25, 
            13000, 
            400,
            "playerap_m_fur", 
            true)]
        ApartmentMediumStyle2Furnished = 6,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Large Apartment - Style 1", 
            70, 
            25000, 
            800,
            "apartment_3", 
            true)]
        ApartmentLargeStyle1 = 7,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Large Apartment - Style 2", 
            70, 
            25000, 
            800,
            "playerap_l_unf", 
            true)]
        ApartmentLargeStyle2 = 8,
        [PropertyLayoutType(
            PropertyType.Apartment,
            "Large Apartment - Style 2 (Furnished)",
            35, 
            30000, 
            900,
            "playerap_l_fur", 
            true)]
        ApartmentLargeStyle2Furnished = 9,

    }

    public class PropertyLayoutTypeAttribute : Attribute
    {
        public PropertyType PropertyType { get; set; }
        public string Name { get; set; }
        public int FurnitureLimit { get; set; }
        public bool IsActive { get; set; }
        public int InitialPrice { get; set; }
        public int PricePerDay { get; set; }
        public string AreaInstanceResref { get; set; }

        public PropertyLayoutTypeAttribute(
            PropertyType propertyType,
            string name,
            int furnitureLimit,
            int initialPrice,
            int pricePerDay,
            string areaInstanceResref,
            bool isActive)
        {
            PropertyType = propertyType;
            Name = name;
            FurnitureLimit = furnitureLimit;
            InitialPrice = initialPrice;
            PricePerDay = pricePerDay;
            AreaInstanceResref = areaInstanceResref;
            IsActive = isActive;
        }
    }
}