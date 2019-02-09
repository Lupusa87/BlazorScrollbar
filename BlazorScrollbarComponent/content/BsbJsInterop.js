﻿window.BsbJsInteropFunctions = {
    alert: function (message) {
        return alert(message);
    },
    log: function (message) {
        return log(message);
    },
    GetElementBoundingClientRect: function (obj) {

        if (document.getElementById(obj["id"]) !== null) {
            let rect = document.getElementById(obj["id"]).getBoundingClientRect();

            let myleft = rect.left.toFixed(2) + window.scrollX;
            let mytop = rect.top.toFixed(2) + window.scrollY;

            obj["dotnethelper"].invokeMethodAsync('invokeFromjs', obj["id"], myleft, mytop);
            return true;
        }
        else {
            return false;
        }
    },

};