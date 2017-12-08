function smothscroller(settings) {
    var self = this;
    self.settings = settings || { step: 200, frequecy: 30 };
    self.scroll = function (x, y) {
        var pos = self.getScroller();
        //console.log("pos.x=" + pos.x + ",pos.y=" + pos.y + ",tar.y=" + y);
        var curY = pos.y;
        if (curY > y) {
            self.scrolltop(x, y);
        } else {
            self.scrolldown(x, y);
        }
    };
    self.scrolltop = function (x, y) {
        var pos = self.getScroller();
        var curY = pos.y;
        if (curY <= y) {
            return;
        }
        var step = self.settings.step;
        if (curY < step) {
            step = curY;
        }
        window.scrollTo(x, curY - step);
        setTimeout(function () {
            self.scroll(x, y);
        }, self.settings.frequecy);
    };
    self.scrolldown = function (x, y) {
        var pos = self.getScroller();
        var curY = pos.y;
        if (curY >= y) {
            return;
        }
        var step = self.settings.step;
        if ((y - curY) < step) {
            step = y - curY;
        }
        window.scrollTo(x, curY + step);
        setTimeout(function () {
            self.scroll(x, y);
        }, self.settings.frequecy);
    };
    self.getScroller = function () {
        var x = 0, y = 0;
        if (window.scrollY) {
            return { x: 0, y: window.scrollY };
        } else if (document.documentElement) {
            return { x: 0, y: document.documentElement.scrollTop };
        } else if (document.body) {
            return { x: 0, y: document.body.scrollTop };
        }
        return { x: x, y: y };
    }
    self.scrollto = function (ele) {
        var x = 0;
        var tar;
        if (typeof ele != 'object') {
            tar = document.getElementById(ele);
        } else {
            tar = ele;
        }
        //console.log("scrollto('" + ele + "')");
        var y = tar.offsetTop + (tar.currentStype ? tar.currentStyle.borderTopWidth : 0);
        //console.log("tar.offsetTop=" + y);
        //var x = tar.scrollLeft;
        self.scroll(x, y);
    }
}