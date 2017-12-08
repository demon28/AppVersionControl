(function ($) {
	var box = window.bootbox || {};
	box.loading = {
		show: function (msg) {
			var mask = $("<div class='bootbox-mask'></div>").css({
				"position": "absolute",
				"position": "fixed",
				"width": "100%",
				"left": "0",
				"right": "0",
				"top": "0",
				"bottom": "0",
				"filter": "alpha(opacity=50)",
				"opacity": "0.5",				
				"background": "#000",
				"z-index": "9999"
			});
			$("body").append(mask);
			var loadingContainer = $("<div class='bootbox-loading-container'></div>").css({
				"position": "absolute",
				"position": "fixed",
				"top": "20%",
				"border": "3px solid #ccc",
				"background": "#fff",
				"z-index":"10000"
			});
			var loadingWrap = $("<div class='bootbox-loading-wrap'></div>");
			var loadingContent = $("<div class='bootbox-loadding-content'></div>").css({
				"padding":"10px"
			});
			var loadingSpin = $("<label class='icon-spinner icon-spin'></label>").css({
				"margin-right":"5px"
			});
			var loadingMsg = $("<span class='bootbox-loading-msg'></span>").text(msg);

			loadingContent.append(loadingSpin);
			loadingContent.append(loadingMsg);
			loadingWrap.append(loadingContent);

			loadingContainer.append(loadingWrap);
			$("body").append(loadingContainer);

			var width = $(".bootbox-loading-container").width();
			$(".bootbox-loading-container").css({ "left": ($(window).width() - width) / 2 });
		},
		dismiss: function () {
			$(".bootbox-mask").remove();
			$(".bootbox-loading-container").remove();
		}
	}
	return box;
})(jQuery)