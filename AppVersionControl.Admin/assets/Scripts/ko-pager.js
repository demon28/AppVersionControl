function pageModel() {
    this.currentPageIndex = 1;
    this.MaxPageIndex = 1;
    this.loadData = function () { };
    this.pagesize = 10;
    this.eleid = "";
}
function koViewModel() {
    var self = this;
    self.Data = [];
}
function renderPage(options) {
    var currentPageIndex = options.pageindex;
    var MaxPageIndex = options.MaxPageIndex;
    var loadData = options.loadData;
    var pagesize = options.pagesize || 10;
    var $this = $("#" + options.eleid).parent();
    var ul = $("<ul></ul>").addClass("pagination");
    var prev = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-left'></i>"))).addClass("prev");
    if (currentPageIndex == 1) {
        prev.addClass("disabled");
    }

    var next = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-right'></i>"))).addClass("next");
    if (MaxPageIndex <= 1 || currentPageIndex == MaxPageIndex) {
        next.addClass("disabled");
    }
    var recordsinfo = $("<li class='disabled'></li>").append($("<a></a>")
        .append("<span>共</span><span class='totalrecords'>" + options.totalRecords + "</span><span>条，每页</span>" +
        "<span class='pagesize'>" + pagesize + "</span>条，<span></span>" + "<span class='maxpageindex'>" + MaxPageIndex + "</span><span>页</span>"));
    //var pagesizeoptions = $("<li class='selectpagesize' style='cursor:pointer'></li>").append($("<a></a>").append("<span class='currpagesize'>" + options.pagesize + "<span><i class='icon-chevron-down'></i>")
    //    .append($("<div class='relative hide'></div>").append($("<div style='position:absolute;left:0;border:1px solid #e0e8eb;top:31px;width:100%;'></div>").
    //    append($("<ul class='options'></ul>").append($("<li>10</li>")).append($("<li>20</li>")).append($("<li>50</li>")).append($("<li>100</li>"))
    //    ))));
    //pagesizeoptions.click(function () {
    //    console.log("fuck errors");
    //    if ($(this).find(".relative").is(".hide")) {
    //        $(this).find(".relative").removeClass("hide");
    //    } else {
    //        $(this).find(".relative").addClass("hide");
    //    }
    //});
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
        var li_html = $("<li></li>");
        if (currentPageIndex == i)
            li_html.addClass("active disabled");
        var item = li_html.append($("<a></a>").html(i));
        ul.append(item);
    }
    ul.append(next);
    ul.append(recordsinfo);
    //ul.append(pagesizeoptions);
    ul.children("li").click(function () {
        if (!$(this).is(".disabled")) {
            var index = 1;
            var pagesize = options.pagesize;
            if ($(this).is(".selectpagesize")) {
                return;
            } else {
                index = $(this).text();
            }
            if (index.length == 0) {
                index = ul.find(".active").text();
                if ($(this).is(".prev") && index > 1) {
                    index--;
                } else if ($(this).is(".next") && index < MaxPageIndex) {
                    index++;
                }
            }
            var arg = $.extend({ "pageindex": parseInt(index), "pagesize": pagesize }, options);
            arg.pageindex = parseInt(index);
            loadData(arg);
        }
    });
    if ($this.parent().find(".dataTables_paginate").length > 0) {
        $this.parent().find(".dataTables_paginate").empty().append(ul);
    } else {
        var div_pagination = $("<div class=\"dataTables_paginate paging_bootstrap\"></div>");
        div_pagination.append(ul);
        $this.after(div_pagination);//.empty().append(ul);
    }
}
function renderLoading(eleid) {
    var loadname = eleid + "-loading-" + new Date().valueOf();
    var $this = $("#" + eleid);
    $this.attr("data-loading-id", loadname);
    var count = $("#" + eleid).find("tr").eq(0).find("td,th").length;
    $this.find("tbody").empty();
    var tr = $("<tr></tr>");
    var td = $("<td></td>").attr("colspan", count);
    var wrap = $("<div></div>").addClass("data-loading-wrap text-center");
    var span = $("<span></span>").css({ "border": "1px solid #aaa", "padding": "5px 10px", "line-height": "16px" });
    var img = $("<img />").attr("src", "/assets/images/ko_loading.gif").addClass("icon");
    var tips = $("<span></span>").html("正在加载数据...");
    span.append(img);
    span.append(tips);
    wrap.append(span);
    td.append(wrap);
    tr.append(td);
    if ($this.get(0).tagName != "TABLE") {
        var table = $("<table></table>").attr("id", loadname);
        table.append(tr);
        $this.append(table);
    } else {
        tr.attr("id", loadname);
        $this.append(tr);
    }
}
function renderWhenNoData(eleid) {
    var loadname = eleid + "-no-data-" + new Date().valueOf();
    var $this = $("#" + eleid);
    $this.attr("data-nodata-id", loadname);
    var count = $("#" + eleid).find("tr").eq(0).find("td,th").length;
    $this.find("tbody").empty();
    var tr = $("<tr></tr>");
    var td = $("<td></td>").attr("colspan", count);
    var wrap = $("<div></div>").addClass("data-loading-wrap text-center");
    var span = $("<span></span>").css({ "border": "1px solid #aaa", "padding": "5px 10px", "line-height": "16px" });
    //var img = $("<img />").attr("src", "/asserts/images/loading.gif").addClass("icon");
    var tips = $("<span></span>").html("暂无数据");
    //span.append(img);
    span.append(tips);
    wrap.append(span);
    td.append(wrap);
    tr.append(td);
    console.log($this.get(0).tagName);
    if ($this.get(0).tagName != "TABLE") {
        var table = $("<table style='width:100%;'></table>").attr("id", loadname).addClass("ajax-nodata");
        table.append(tr);
        $this.append(table);
    } else {
        tr.addClass("ajax-nodata").attr("id", loadname);
        $this.append(tr);
    }
}
(function ($) {
    $.extend({
        DT: {
            init: function (opt) {
                ///<summary>加载分页</summary>
                ///<param name='opt' type='Json'>
                ///{
                ///<para>url:'',</para>
                ///<para>eleid:'',               </para>
                ///<para>enablePaginate:true,    </para>
                ///<para>pageindex:1,            </para>
                ///<para>pagesize:10,            </para>
                ///<para>query:{},               </para>
                ///<para>errorfunc:function(){}, </para>
                ///<para>success:function()     </para>
                ///<para>}</para>
                ///</param>
                var container = $("#" + opt.eleid).parent().parent();
                var activeIndex = container.find(".dataTables_paginate > .pagination > li.active");
                //console.log(activeIndex);
                var currentPageIndex = activeIndex.length > 0 ? activeIndex.text() : undefined;
                if (opt.pageindex) {

                }
                else if (!opt.pageindex && !currentPageIndex) {
                    opt.pageindex = 1;
                } else {
                    try {
                        opt.pageindex = parseInt(currentPageIndex);
                    } catch (e) {
                        opt.pageindex = 1;
                    }
                }
                if (!opt.pagesize) {
                    opt.pagesize = 10;
                }
                this.loadData(opt);
            },

            loadData: function (opt) {
                var pageindex = opt.pageindex || 1;
                var pagesize = opt.pagesize || 10;
                var url = opt.url || "";
                if (typeof(opt.query) == 'string') {
                    var urlquery = opt.query;
                    opt.query = {};
                    var array = urlquery.split('&');
                    for (var i in array) {
                        var keyvalue = array[i].split('=');
                        if (keyvalue[1]) {
                            opt.query[keyvalue[0]] = decodeURI(keyvalue[1]);
                        }
                    }
                }
                var query = opt.query || {};
                var errorfunc = opt.errorfunc || alert;
                var enablePaginate = opt.enablePaginate;
                var searchData = query;
                if (enablePaginate) {
                    searchData = $.extend(query, { "pageindex": pageindex, "pagesize": pagesize });
                }
                renderLoading(opt.eleid);
                var pModel = $.extend(opt, { loadData: this.loadData, MaxPageIndex: 1 });
                $.ajax({
                    "url": url,
                    "data": searchData,
                    "type": "POST",
                    "success": function (resp) {
                        var viewModel = new koViewModel();
                        if (resp.Success) {
                            var loadingid = $("#" + opt.eleid).attr("data-loading-id");
                            $("#" + loadingid).remove();
                            if (resp.Content && resp.Content.Data && resp.Content.Data.length > 0) {

                                viewModel.Data = resp.Content.Data;
                                ko.applyBindings(viewModel, document.getElementById(opt.eleid));
                                if (enablePaginate) {
                                    var maxPageIndex = parseInt(resp.Content.Count / pagesize);
                                    if (resp.Content.Count % pagesize) {
                                        maxPageIndex++;
                                    }
                                    pModel.MaxPageIndex = maxPageIndex;
                                    pModel.totalRecords = resp.Content.Count;
                                    pModel.pagesize = pagesize;
                                    renderPage(pModel);
                                }
                            } else {
                                $(".ajax-nodata").remove();
                                if (opt.renderWhenNoData) {
                                    opt.renderWhenNoData(opt.eleid);
                                } else {
                                    renderWhenNoData(opt.eleid);
                                }
                            }

                            if (opt.success) {
                                opt.success.apply(viewModel, [resp]);
                            }
                        } else {
                            var loadingid = $("#" + opt.eleid).attr("data-loading-id");
                            $("#" + loadingid).remove();
                            errorfunc(resp.Message);
                        }
                    },
                    "error": function () {
                        var loadingid = $("#" + opt.eleid).attr("data-loading-id");
                        $("#" + loadingid).remove();
                        errorfunc("连接服务器失败");
                    }
                })
            }
        }
    });
})(jQuery);

$(function () {
    $(".ko-pager").each(function (index, item) {
        if ($(item).get(0).tagName.toUpperCase() == "INPUT" || $(item).get(0).tagName.toUpperCase() == "BUTTON") {
            $(item).bind("click", function () {
                loadDataByKoAttribute(item);
            });
        } else {
            loadDataByKoAttribute(item);
        }
    });
});
function loadDataByKoAttribute(item) {
    var elementid = $(item).attr("data-ko-element");
    var url = $(item).attr("data-ko-url");
    var queryinfo = eval("(" + $(item).attr("data-ko-query") + ")");
    var enablePaginate = $(item).attr("data-ko-enablepaginate");
    var pagesize = $(item).attr("data-ko-pagesize") || 10;
    var successName = $(item).attr("data-ko-success");
    var successFunction = function () { };
    if (successName) {
        successFunction = eval(successName);
    }
    var query = {};
    for (var key in queryinfo) {
        if ($(queryinfo[key]).length > 1) {
            var value = "";
            $(queryinfo[key]).each(function (i, ele) {
                value += $(ele).val();
                if (i + 1 < $(queryinfo[key]).length) {
                    value += ",";
                }
            });
            query[key] = value;
        } else {
            query[key] = $(queryinfo[key]).val();
        }
    }

    $.DT.init({
        eleid: elementid,
        url: url,
        enablePaginate: enablePaginate == "true" ? true : false,
        pagesize: pagesize,
        query: query,
        success: successFunction
    });
}