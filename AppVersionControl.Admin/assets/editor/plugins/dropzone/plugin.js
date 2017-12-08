(function () {
    //Section 1 : 按下自定义按钮时执行的代码
    var a = {
        exec: function (editor) {
            show();
        }
    },
  b = 'dropzone';
    CKEDITOR.plugins.add(b, {
        init: function (editor) {
            editor.addCommand(b, a);
            editor.ui.addButton('dropzone', {
                label: '上传图片',
                icon: this.path + 'dropzone.png',
                command: b
            });
        }
    });
})();