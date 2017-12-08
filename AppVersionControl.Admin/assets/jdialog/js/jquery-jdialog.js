(function () {
    $.fn.extend({
        Popup: function (j) {
            j = j || {};
            var width = j.width || $(this).width();
            var height = j.height || $(this).height();
            var title = j.title || "";
            //var isReseve = j.isReseve || false;
            $(this).addClass("jdialog-show");
            var position = $(this).parent().children().index($(this));
            var cls = "jdialog" + new Date().valueOf();
            $(this).parent().addClass(cls);
            var dialog_wrapper = $("<div id='jdialog-dialog-wrapper'></div>");
            var dialog_title = $("<div class='jdialog-dialog-title'></div>");
            var dialog_logo = $("<span class='jdialog-dialog-logo'></span>");
            var dialog_title_sequece = $("<span class='jdialog-dialog-sequece'></span>").html(title);
            var dialog_esa_wrap = $("<div class='jdialog-dialog-escwrap'></div>");
            var dialog_close_span = $("<span class='jdialog-dialog-closebutton' onclick=\"close_jdialog('" + cls + "'," + position + ")\"></span>");
            var dialog_content_wrapper = $("<div class='jdialog-dialog-content'></div>");
            dialog_esa_wrap.append(dialog_close_span);
            dialog_title.append(dialog_logo);
            dialog_title.append(dialog_title_sequece);
            dialog_title.append(dialog_esa_wrap);
            dialog_wrapper.append(dialog_title);
            dialog_wrapper.append(dialog_content_wrapper);
            //$(this).addClass(cls).hide();
            dialog_content_wrapper.append($(this));
            dialog_wrapper.css({
                "left": (getScreenSize().width - width) / 2,
                "top": (getScreenSize().height - height) / 2
            });
            var body;
            if (window.parent && window.parent.$)
                body = window.parent.$("body");
            else
                body = $("body");
            createMask();
            if ($("form").length > 0) {
                $("form").eq(0).append(dialog_wrapper);
            } else {
                body.append(dialog_wrapper);
            }
        },
        pulldown: function () {
            clearMask();
        }
    });
    var showtimer;
    var timeouttimer;
    var delaytimer;
    function clearTimer() {
        clearTimeout(delaytimer);
        clearTimeout(showtimer);
        clearTimeout(timeouttimer);
    };
    $.extend({
        jdialog: {
            Popup: function (t, j) {
                j = j || {};
                var width = j.width || $(t).width();
                var height = j.height || $(t).height();
                var title = j.title || "";
                var frame = j.frame || false;
                var url = j.url || "";
                $(t).addClass("jdialog-show");
                var position = $(this).parent().children().index($(t));
                var cls = "jdialog" + new Date().valueOf();
                $(t).parent().addClass(cls);
                var dialog_wrapper = $("<div id='jdialog-dialog-wrapper'></div>");
                var dialog_title = $("<div class='jdialog-dialog-title'></div>");
                var dialog_logo = $("<span class='jdialog-dialog-logo'></span>");
                var dialog_title_sequece = $("<span class='jdialog-dialog-sequece'></span>").html(title);
                var dialog_esa_wrap = $("<div class='jdialog-dialog-escwrap'></div>");
                var dialog_close_span = $("<span class='jdialog-dialog-closebutton' onclick=\"close_jdialog('" + cls + "'," + position + ")\"></span>");
                var dialog_content_wrapper = $("<div class='jdialog-dialog-content'></div>");
                dialog_esa_wrap.append(dialog_close_span);
                dialog_title.append(dialog_logo);
                dialog_title.append(dialog_title_sequece);
                dialog_title.append(dialog_esa_wrap);
                dialog_wrapper.append(dialog_title);
                dialog_wrapper.append(dialog_content_wrapper);
                if (frame) {
                    var frame_loading = $("<div id='jdialog-frame-loading'>正在努力为您加载内容......</div>").css({
                        "width": width + "px",
                        "height": height + "px",
                        "line-height": height + "px",
                        "text-align": "center"
                    });;
                    var iframe = $("<iframe scrolling=\"auto\" onload='clearLoadding(this)' frameborder=\"0\"></iframe>").attr("src", url).css({
                        "width": width + "px",
                        "height": height + "px",
                        "display": "none"
                    });
                    //iframe.append($(t));
                    dialog_content_wrapper.append(frame_loading);
                    dialog_content_wrapper.append(iframe);
                } else {
                    dialog_content_wrapper.append($(t));
                }

                dialog_wrapper.css({
                    "left": (getScreenSize().width - width) / 2,
                    "top": (getScreenSize().height - height) / 2
                });
                var body;
                if (window.parent && window.parent.$)
                    body = window.parent.$("body");
                else
                    body = $("body");
                createMask();

                body.append(dialog_wrapper);
            }
        },
        msg: {
            show: function (type, msg, timeout) {
                clearTimeout(delaytimer);
                clearTimeout(showtimer); //清除计时器
                clearTimeout(timeouttimer);
                delaytimer = setTimeout(function () {
                    type = type || 1;
                    msg = msg || "操作成功";
                    timeout = timeout || 3;
                    timeout = timeout * 1000;
                    createMask();
                    createMsgPanel(type, msg);
                    if (type != 2) {
                        showtimer = setTimeout(function () {
                            $.msg.hide();
                        }, timeout);
                    } else {
                        timeouttimer = setTimeout(function () {
                            $.msg.show(2, "请您耐心等待，仍然在努力加载中....");
                        }, 10000);
                    }
                }, 500);
            },
            hide: function () {
                clearTimeout(delaytimer);
                clearTimeout(showtimer);
                clearTimeout(timeouttimer);
                clearMask();
                clearMsg();
            },
            msgType: {
                Error: -1,
                Tip: 0,
                Success: 1,
                Loadding: 2
            }
        },
        http: {
            doPost: function (url, data, success, fail) {
                $.msg.show(2, "正在努力加载中....");
                $.ajax({
                    url: url,
                    data: data,
                    type: "POST",
                    success: function (responseText) {
                        try {
                            var json = {};
                            if (!isJSON(responseText))
                                json = eval("(" + responseText + ")");
                            else
                                json = responseText;
                            var r = success(json);
                            if (!r.IsSuccess)
                                $.msg.show(-1, r.Msg, 3);
                            else
                                $.msg.hide();
                        }
                        catch (ex) {
                            $.msg.show(-1, "出现致命错误", 3);
                        }
                    },
                    error: function () {
                        try {
                            fail();
                        } catch (e) {
                            $.msg.show(-1, "出现未知错误", 3);
                        }

                    }
                });
            }
        }
    });

})(jQuery);

$(function () {
    $(".jdialog-frame").click(function () {
        var url = $(this).attr("href");
        var text = $(this).html();
        var urlpara = getUrlParams(url);
        var width = urlpara.width || 800;
        var height = urlpara.height || 500;
        var p = { "width": width, "height": height, "title": text, "frame": true, "url": url };
        $.jdialog.Popup("", p);
        return false;
    });
})
function clearLoadding(tar) {
    $("#jdialog-frame-loading").remove();
    $(tar).css("display", "block");
}
function getUrlParams(url) {
    var a1 = url.split('?');
    if (a1.length < 2)
        return {};
    var a2 = a1[1].split('&');
    var result = {};
    for (var i in a2) {
        try {
            var tmp = a2[i].split('=');
            var key = tmp[0];
            var value = tmp[1];
            result[key] = value;
        } catch (e) {

        }
    }
    return result;
}

function close_jdialog(v, index) {
    //alert(index);
    var ele = $("." + v);
    ele.removeClass(v);
    clearMask();
    var body;
    if (window.parent && window.parent.$)
        body = window.parent.$("body");
    else
        body = $("body");
    var panel = body.find("#jdialog-dialog-wrapper .jdialog-dialog-content").children();
    panel.removeClass("jdialog-show");
    var len = ele.children().length;
    if (len <= 0) {
        ele.append(panel);
    }
    else {
        if (index == 0) {
            panel.insertBefore(ele.children().eq(index));
        }
        else {
            panel.insertAfter(ele.children().eq(index - 1));
        }
    }
    body.find("#jdialog-dialog-wrapper").remove();
    //body.find("." + v).removeClass(v).show();
}

function createMask() {
    var body;
    if (window.parent && window.parent.$) {
        body = window.parent.$("body");
    }
    else {
        body = $("body");
    }
    var exist = body.find("#jdialog-maskwindow");
    if (exist.length > 0)
        return;
    var mask = $("<div id='jdialog-maskwindow'></div>").addClass("jdialog-maskwindow").css({
        "height": getScreenSize().height
    });

    body.append(mask);
}
function clearMask() {
    var mask = $("#jdialog-maskwindow");
    if (mask.length > 0)
        mask.fadeOut().remove();
    if (window.parent && window.parent.$) {
        var parentwrapper = window.parent.$("#jdialog-maskwindow");
        if (parentwrapper.length > 0)
            parentwrapper.fadeOut().remove();
    }
}
function createMsgPanel(type, msg) {
    var exist;
    if (window.parent && window.parent.$) {
        exist = window.parent.$("#jdialog-msg-wrapper");
    } else {
        exist = $("#jdialog-msg-wrapper");
    }
    if (exist.length > 0) {
        var existcontent = exist.find(".jdialog-msg-content");
        var existimg = exist.find(".jdialog-msg-img");
        existimg.removeClass("jdialog-msg-error").removeClass("jdialog-msg-tip").removeClass("jdialog-msg-ok").removeClass("jdialog-msg-loading");
        existcontent.removeClass("jdialog-loading-content")
        if (type == -1)
            existimg.addClass("jdialog-msg-error");
        else if (type == 0)
            existimg.addClass("jdialog-msg-tip");
        else if (type == 1)
            existimg.addClass("jdialog-msg-ok");
        else if (type == 2) {
            existimg.addClass("jdialog-msg-loading");
            existcontent.addClass("jdialog-loading-content");
            msg = "<span class='jdialog-loading-img'></span><span>" + msg + "</span>";
        }
        existcontent.empty().html(msg);
    } else {
        var wrapper = $("<div id='jdialog-msg-wrapper'></div>");
        var typeimg = $("<div class='jdialog-msg-img'></div>");
        var content = $("<div class='jdialog-msg-content'></div>");
        var closeimg = $("<div class='jdialog-msg-right'></div>");
        if (type == -1)
            typeimg.addClass("jdialog-msg-error");
        else if (type == 0)
            typeimg.addClass("jdialog-msg-tip");
        else if (type == 1)
            typeimg.addClass("jdialog-msg-ok");
        else if (type == 2) {
            typeimg.addClass("jdialog-msg-loading");
            content.addClass("jdialog-loading-content");
            msg = "<span class='jdialog-loading-img'></span><span>" + msg + "</span>";
        }
        content.html(msg);
        wrapper.append(typeimg);
        wrapper.append(content);
        wrapper.append(closeimg);
        var body;
        if (window.parent && window.parent.$) {
            body = window.parent.$("body");
        }
        else {
            body = $("body");
        }
        body.append(wrapper);
    }
    var msgwrapper;
    if (window.parent && window.parent.$) {
        msgwrapper = window.parent.$("#jdialog-msg-wrapper");
    } else {
        msgwrapper = $("#jdialog-msg-wrapper");
    }

    msgwrapper.css({
        "top": (getScreenSize().height - msgwrapper.height()) / 2,
        "left": (getScreenSize().width - msgwrapper.width()) / 2
    });
}
function clearMsg() {
    var wrapper = $("#jdialog-msg-wrapper");
    if (wrapper.length > 0)
        wrapper.fadeOut().remove();
    if (window.parent && window.parent.$) {
        var parentwrapper = window.parent.$("#jdialog-msg-wrapper");
        if (parentwrapper.length > 0)
            parentwrapper.fadeOut().remove();
    }
}

function getScreenSize() {
    if (window.parent && window.parent.$) {
        return { "width": $(window.parent.window).width(), "height": $(window.parent.window).height() };
    } else {
        return { "width": $(window).width(), "height": $(window).height() };
    }
}

function isJSON(obj) {
    var isjson = typeof (obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length;
    return isjson;
}

window.addEventListener("resize", function () {
    var width = $("#jdialog-dialog-wrapper").width();
    var height = $("#jdialog-dialog-wrapper").height()
    console.log("jdialog.resize:{width:" + width + ",height:" + height);
    $("#jdialog-dialog-wrapper").css({
        "left": (getScreenSize().width - width) / 2,
        "top": (getScreenSize().height - height) / 2
    });

    $("#jdialog-maskwindow").css({
        "height": getScreenSize().height
    });
}, false);