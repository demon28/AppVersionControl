$.fn.extend({
    renderPage: function (options) {
        var currentPageIndex = options.currentPageIndex;
        var MaxPageIndex = options.MaxPageIndex;
        var appendNode = options.appendNode;
        var loadData = options.loadData;
        var $this = $(this);
        var ul = $("<ul></ul>").addClass("pagination");
        var prev = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-left'></i>"))).addClass("prev");
        if (currentPageIndex == 1) {
            prev.addClass("disabled");
        }

        var next = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-right'></i>"))).addClass("next");
        if (MaxPageIndex <= 1 || currentPageIndex == MaxPageIndex) {
            next.addClass("disabled");
        }
        var minIndex = currentPageIndex - 5;
        var plus = 0;
        if (minIndex <= 0) {
            plus = 0 - minIndex;
            minIndex = 1;
        }
        var maxIndex = currentPageIndex + 5 + plus;
        if (maxIndex > MaxPageIndex) {
            maxIndex = MaxPageIndex;
        }
        ul.append(prev);
        for (var i = minIndex; i <= maxIndex; i++) {
            var li_html = $("<li></li>");//onclick='goToPage(" + i + ")'
            if (currentPageIndex == i)
                li_html.addClass("active disabled");
            var item = li_html.append($("<a></a>").html(i));
            ul.append(item);
        }
        ul.append(next);
        ul.children("li").click(function () {
            if (!$(this).is(".disabled")) {
                var index = $(this).text();
                if (index.length == 0) {
                    index = ul.find(".active").text();
                    if ($(this).is(".prev") && index > 1) {
                        index--;
                    } else if ($(this).is(".next") && index < MaxPageIndex) {
                        index++;
                    }
                }
                loadData(parseInt(index));
            }
        });
        $this.empty().append(ul);
    },
    renderLoading: function (columnCount) {
        $(this).empty();
        var tr = $("<tr></tr>");
        var td = $("<td></td>").attr("colspan", columnCount);
        var wrap = $("<div></div>").addClass("data-loading-wrap text-center");
        var span = $("<span></span>").css({ "border": "1px solid #aaa", "padding": "5px 10px", "line-height": "16px" });
        var img = $("<img />").attr("src", "/asserts/images/loading.gif").addClass("icon");
        var tips = $("<span></span>").html("正在加载数据...");
        span.append(img);
        span.append(tips);
        wrap.append(span);
        td.append(wrap);
        tr.append(td);
        $(this).append(tr);
    },
    renderNoData: function (columnCount) {
        $(this).empty();
        var tr = $("<tr></tr>");
        var td = $("<td></td>").attr("colspan", columnCount);
        var wrap = $("<div></div>").addClass("data-loading-wrap text-center");
        var span = $("<span></span>");//.css({ "border": "1px solid #aaa", "padding": "5px 10px", "line-height": "16px" });
        //var img = $("<img />").attr("src", "/asserts/images/loading.gif").addClass("icon");
        var tips = $("<span></span>").html("暂无有效数据可供查看");
        //span.append(img);
        span.append(tips);
        wrap.append(span);
        td.append(wrap);
        tr.append(td);
        $(this).append(tr);
    }
});
function PageModel(loadDataFunc) {
    this.currentPageIndex = 1;
    this.MaxPageIndex = 1;
    //this.appendNode = undefined;
    this.loadData = loadDataFunc;
};
function createPagination(currentPageIndex, MaxPageIndex, appendNode, func) {
    var ul = $("<ul></ul>").addClass("pagination");
    var prev = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-left'></i>"))).addClass("prev");
    if (currentPageIndex == 1) {
        prev.addClass("disabled");
    }

    var next = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-right'></i>"))).addClass("next");
    if (MaxPageIndex <= 1 || currentPageIndex == MaxPageIndex) {
        next.addClass("disabled");
    }
    var minIndex = currentPageIndex - 5;
    var plus = 0;
    if (minIndex <= 0) {
        plus = 0 - minIndex;
        minIndex = 1;
    }
    var maxIndex = currentPageIndex + 5 + plus;
    if (maxIndex > MaxPageIndex) {
        maxIndex = MaxPageIndex;
    }
    ul.append(prev);
    for (var i = minIndex; i <= maxIndex; i++) {
        var li_html = $("<li></li>");//onclick='goToPage(" + i + ")'
        if (currentPageIndex == i)
            li_html.addClass("active disabled");
        var item = li_html.append($("<a></a>").html(i));
        ul.append(item);
    }
    ul.append(next);
    ul.children("li").click(function () {
        func($(this).text() + "1");
    });
    $(".dataTables_paginate").empty().append(ul);
}


//function goToPage(index) {
//    readyLoad(index, 10, function (JsonData) {
//        if (JsonData.IsSuccess) {
//            viewModel.Groups(JsonData.Data);
//            createPagination(JsonData.CurrentPageIndex, JsonData.TotalPageCount, undefined)
//        } else {
//            alert("加载列表失败," + JsonData.Message);
//        }
//    });
//}
function readyLoad(url, pageindex, pagesize, successfunc, searchData) {
    var tmpData = { "PageIndex": pageindex, "PageSize": pagesize };
    var postData = $.extend(tmpData, searchData);
    $.ajax({
        url: url,
        data: postData,
        type: "POST",
        success: successfunc,
        error: function () {
            alert("加载数据失败");
        }
    });
}