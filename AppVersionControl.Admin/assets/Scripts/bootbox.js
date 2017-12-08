var bootbox = function (settings) {
    if (window.attachEvent) {
        window.attachEvent("onresize", alignCenterContainer);
    } else {
        window.addEventListener("resize", alignCenterContainer);
    }
    var self = this;
    self.setting = settings || {};
    self.alert = function (str) {
        self.createMask();
        var container = createContainer();

        var content = document.createElement("div");
        content.className = "bootbox-content";
        content.style.padding = "20px 40px"
        content.innerHTML = str;

        var buttonGroup = document.createElement("div");
        buttonGroup.style.background = "#f3f3f3";
        buttonGroup.style.overflow = "hidden";
        buttonGroup.style.textAlign = "right";
        var btnOK = document.createElement("button");
        btnOK.onclick = function () {
            self.clear();
        };
        btnOK.className = "";
        btnOK.style.border = "none";
        btnOK.style.margin = "5px 10px"
        btnOK.style.background = "#ccc";
        btnOK.textContent = "OK";

        buttonGroup.appendChild(btnOK);

        container.appendChild(content);
        container.appendChild(buttonGroup);

        document.body.appendChild(container);
        alignCenterContainer();
    };
    self.confirm = function (data) {
        var confirmData = data || {
            Message: "NONE", Buttons: [
                { text: "OK", id: "btnOK", handler: function () { } },
                { text: "Cancel", id: "btnCancel", handler: function () { } }]
        };


    };
    self.loading = function (str) {
        self.createMask();
        var container = createContainer();

        var content = document.createElement("div");
        content.className = "bootbox-content";
        content.style.padding = "10px 20px"


        var loadingimg = document.createElement("img");
        loadingimg.src = "/assets/images/bootbox_loading.gif";
        loadingimg.style.verticalAlign = "middle";
        loadingimg.style.float = "left";

        var msgDiv = document.createElement("div");
        msgDiv.innerHTML = str;
        msgDiv.style.wordBreak = "none";
        msgDiv.style.marginLeft = "18px";
        content.appendChild(loadingimg);
        content.appendChild(msgDiv);

        container.appendChild(content);

        document.body.appendChild(container);
        alignCenterContainer();
    };
    self.clear = function () {
        var mask = document.getElementById("bootbox-mask");
        var container = document.getElementById("bootbox-container");
        try {
            mask.remove();
            container.remove();
        } catch (e) {
            if (mask) {
                var mask_parentNode = mask.parentNode;
                mask_parentNode.removeChild(mask);
            }
            if (container) {
                var container_parentNode = container.parentNode;
                container_parentNode.removeChild(container);
            }
        }
    };
    self.createMask = function () {
        var existMask = document.getElementById("bootbox-mask");
        var height = 0;
        if (document.body) {
            height = document.body.clientHeight;
        } else if (document.documentElement) {
            height = document.documentElement.clientHeight;
        }
        if (window.innerHeight && window.innerHeight > height) {
            height = window.innerHeight;
        }
        if (!existMask) {
            //var height = document.body.clientHeight;
            var mask = document.createElement("div");
            mask.style.height = height + "px";
            mask.id = "bootbox-mask";
            mask.style.width = "100%";
            mask.style.position = "absolute";
            mask.style.opacity = "0.4";
            mask.style.filter = "alpha(opacity=40)";
            mask.style.top = "0";
            mask.style.left = "0";
            mask.style.background = "#000000";
            mask.style.zIndex = "9998";
            document.body.appendChild(mask);
        }
    }
    function createContainer() {
        var container = document.createElement("div");
        container.id = "bootbox-container";
        container.style.minWidth = "200px";
        container.style.border = "#ccc 4px solid";
        container.style.background = "#fff";
        container.style.position = "fixed";
        container.style.top = "20%";
        container.style.left = "45%";
        container.style.zIndex = "9999";
        container.style.textAlign = "center";
        container.style.wordBreak = "keep-all";
        return container;
    }
    function alignCenterContainer() {
        var container = document.getElementById("bootbox-container");
        var screenWidth = 1260;
        if (document.body) {
            screenWidth = document.body.clientWidth;
        } else if (document.documentElement) {
            screenWidth = document.documentElement.clientWidth;
        }
        container.style.left = ((screenWidth - container.clientWidth) / 2) + "px";
    }
}
/*

#bootbox-container
{
    border: #ccc 4px solid;
    background: #fff;
    position: fixed;
    _position: absolute;
    *position: absolute;
    top: 20%;
    left: 45%;
    z-index: 9999;
    text-align: center;
    -ms-word-break: keep-all;
    word-break: keep-all;
}
*/