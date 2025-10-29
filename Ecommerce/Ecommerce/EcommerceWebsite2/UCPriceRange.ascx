<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPriceRange.ascx.cs" Inherits="EcommerceWebsite2.UCPriceRange" %>

<!-- single sidebar start -->
<div class="sidebar-single">
    <h5 class="sidebar-title">price</h5>
    <div class="sidebar-body">
        <div class="price-range-wrap">
            <div class="price-range" data-min="1" data-max="1000"></div>
            <div class="range-slider">
                <form action="#" class="d-flex align-items-center justify-content-between">
                    <div class="price-input">
                        <label for="amount">Price: </label>
                        <input type="text" id="amount">
                    </div>
                    <button class="filter-btn">filter</button>
                </form>
            </div>
        </div>
    </div>
</div>
<!-- single sidebar end -->