using StruttonTechnologies.Core.ToolKit.Pagination;
using StruttonTechnologies.Core.ToolKit.Pagination.Extensions;
using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;

namespace StruttonTechnologies.Core.ToolKits.UnitTests.Pagination;

public sealed class PaginationTests
{
    [Fact]
    public void PagedRequest_ComputesSkipAndTake()
    {
        var request = new PagedRequest { PageNumber = 3, PageSize = 10 };

        Assert.Equal(20, request.Skip);
        Assert.Equal(10, request.Take);
    }

    [Fact]
    public void PagingMetadata_ComputesNavigationProperties()
    {
        var metadata = new PagingMetadata { PageNumber = 2, PageSize = 10, TotalItemCount = 25 };

        Assert.Equal(3, metadata.TotalPageCount);
        Assert.True(metadata.HasPreviousPage);
        Assert.True(metadata.HasNextPage);
        Assert.Equal(11, metadata.FirstItemIndex);
        Assert.Equal(20, metadata.LastItemIndex);
    }

    [Fact]
    public void PagedResult_Create_BuildsResultAndMetadata()
    {
        var result = PagedResult<int>.Create([1, 2], pageNumber: 2, pageSize: 2, totalItemCount: 5);

        Assert.Equal([1, 2], result.Items);
        Assert.Equal(2, result.Metadata.PageNumber);
        Assert.Equal(5, result.Metadata.TotalItemCount);
    }

    [Fact]
    public void PageValidation_Normalize_ClampsInvalidValues()
    {
        var request = new PagedRequest { PageNumber = 0, PageSize = 999 };

        var normalized = PageValidation.Normalize(request);

        Assert.Equal(PagedRequest.DefaultPageNumber, normalized.PageNumber);
        Assert.Equal(PagedRequest.MaxPageSize, normalized.PageSize);
    }

    [Fact]
    public void PageValidation_ThrowIfInvalid_ThrowsForInvalidPageNumber()
    {
        var request = new PagedRequest { PageNumber = 0, PageSize = 10 };

        Assert.Throws<ArgumentOutOfRangeException>(() => PageValidation.ThrowIfInvalid(request));
    }

    [Fact]
    public void Enumerable_ToPagedResult_ReturnsRequestedPage()
    {
        var result = Enumerable.Range(1, 10).ToPagedResult(new PagedRequest { PageNumber = 2, PageSize = 3 });

        Assert.Equal([4, 5, 6], result.Items);
        Assert.Equal(10, result.Metadata.TotalItemCount);
    }

    [Fact]
    public void Queryable_ToPagedResult_ReturnsRequestedPage()
    {
        var result = Enumerable.Range(1, 10).AsQueryable().ToPagedResult(new PagedRequest { PageNumber = 2, PageSize = 4 });

        Assert.Equal([5, 6, 7, 8], result.Items);
    }

    [Fact]
    public void PagedResult_Map_MapsItemsAndPreservesMetadata()
    {
        var source = PagedResult<int>.Create([1, 2], pageNumber: 1, pageSize: 2, totalItemCount: 2);

        var mapped = source.Map(i => $"Item {i}");

        Assert.Equal(["Item 1", "Item 2"], mapped.Items);
        Assert.Equal(source.Metadata.TotalItemCount, mapped.Metadata.TotalItemCount);
    }
}
