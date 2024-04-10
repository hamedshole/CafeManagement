using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using Shared.Model;

namespace Application.Heplers
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TableEntity, TableModel>();
            CreateMap<CreateTableParameter, TableEntity>();
            CreateMap<UpdateTableParameter, TableEntity>();
            CreateMap<UnitEntity, UnitModel>()
                .ForMember(x => x.Parent, opt => opt.MapFrom(x => x.Parent.Title));
            CreateMap<UnitEntity, UnitDetailModel>();
            CreateMap<CreateUnitParameter, UnitEntity>();
            CreateMap<UpdateUnitParameter, UnitEntity>();
            CreateMap<MaterialEntity, MaterialModel>()
                .ForMember(x=>x.Unit,opt=>opt.MapFrom(x=>x.Unit.Title));
            CreateMap<MaterialEntity, MaterialDetailModel>()
                .ForMember(x => x.UnitPrice, opt => opt.MapFrom(x => x.UnitPrice.Value));
            CreateMap<CreateMaterialParameter, MaterialEntity>()
                .ForMember(x => x.UnitPrice, opt => opt.MapFrom(x => new Money(x.UnitPrice)));
            CreateMap<UpdateMaterialParameter, MaterialEntity>()
                .ForMember(x => x.UnitPrice, opt => opt.MapFrom(x => new Money(x.UnitPrice))); ;
            CreateMap<AdditiveEntity, AdditiveModel>()
                .ForMember(x=>x.Material,opt=>opt.MapFrom(x=>x.Material.Title));
            CreateMap<CreateAdditiveParameter, AdditiveEntity>();
            CreateMap<UpdateAdditiveParameter, AdditiveEntity>();
            CreateMap<AdditiveEntity, AdditiveDetailModel>()
                .ForMember(x=>x.Amount,opt=>opt.MapFrom(x=>x.Amount.Value.ToString("#,#")))
                .ForMember(x=>x.Price,opt=>opt.MapFrom(x=>x.Price.Value));
            CreateMap<ProductCategoryEntity, ProductCategoryModel>();
            CreateMap<CreateProductCategoryParameter, ProductCategoryEntity>();
            CreateMap<UpdateProductCategoryParameter, ProductCategoryEntity>();
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<CreateProductParameter, ProductEntity>()
                .ForMember(x => x.Additives, opt => opt.Ignore())
                .ForMember(x => x.Materials, opt => opt.Ignore());
            CreateMap<UpdateProductParameter, ProductEntity>();
            CreateMap<ProductPriceLogEntity, PriceLogModel>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Price.Value))
                .ForMember(x => x.Start, opt => opt.MapFrom(x => x.StartTime))
                .ForMember(x => x.End, opt => opt.MapFrom(x => x.EndTime));
            CreateMap<AdditivePriceLogEntity, PriceLogModel>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Price.Value))
                .ForMember(x => x.Start, opt => opt.MapFrom(x => x.StartTime))
                .ForMember(x => x.End, opt => opt.MapFrom(x => x.EndTime));
            CreateMap<MaterialPriceLogEntity, MaterialPriceLogModel>()
                .ForMember(x => x.BuyPrice, opt => opt.MapFrom(x => x.BuyPrice.Value))

                .ForMember(x => x.SellPrice, opt => opt.MapFrom(x => x.BuyPrice.Value))
                .ForMember(x => x.Start, opt => opt.MapFrom(x => x.StartTime))
                .ForMember(x => x.End, opt => opt.MapFrom(x => x.EndTime));

        }

       
    }
}
