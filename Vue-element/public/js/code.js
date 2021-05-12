function mycode() {
    (function($, window, document, undefined) {
        function SliderUnlock(elm, options, success) {
            var me = this;
            var $elm = me.checkElm(elm) ? $(elm) : $;
            success = me.checkFn(success) ? success : function() {};
            var opts = {
                successLabelTip: "Successfully Verified",
                duration: 200,
                swipestart: false,
                min: 0,
                max: $elm.width(),
                index: 0,
                IsOk: false,
                lableIndex: 0,
            };
            opts = $.extend(opts, options || {});
            me.elm = $elm;
            me.opts = opts;
            me.swipestart = opts.swipestart;
            me.min = opts.min;
            me.max = opts.max;
            me.index = opts.index;
            me.isOk = opts.isOk;
            me.labelWidth = me.elm.find("#label").width();
            me.sliderBg = me.elm.find("#slider_bg");
            me.lableIndex = opts.lableIndex;
            me.success = success;
        }

        SliderUnlock.prototype.init = function() {
            var me = this;
            me.updateView();
            me.elm
                .find("#label")
                .on("mousedown", function(event) {
                    var e = event || window.event;
                    me.lableIndex = e.clientX - this.offsetLeft;

                    me.handerIn();

                    document.onmousemove = function(ea) {
                        if (!me.isOk) {
                            ea.preventDefault();
                            //var event = ea;//event || window.event;
                            me.index = ea.clientX - me.lableIndex;

                            if (me.index + me.labelWidth >= me.max) {
                                me.index = me.max - me.labelWidth - 2;
                                me.swipestart = false;
                                me.isOk = true;
                            }
                            if (me.index < 0) {
                                me.index = me.min;
                                me.isOk = false;
                            }
                            if (
                                me.index + me.labelWidth + 2 >= me.max &&
                                me.max > 0 &&
                                me.isOk
                            ) {
                                $("#label")
                                    .unbind()
                                    .next("#labelTip")
                                    .text(me.opts.successLabelTip)
                                    .css({
                                        color: "#fff",
                                    });

                                me.success();
                            }
                            me.sliderBg.css("width", me.index + 2);
                            me.elm.find("#label").css("left", me.index + "px");
                        }
                    };

                    document.onmouseup = function(ea) {
                        me.swipestart = false;
                        if (!me.isOk) {
                            me.index = 0;
                            me.sliderBg.animate({
                                    width: 0,
                                },
                                me.opts.duration
                            );

                            me.elm
                                .find("#label")
                                .animate({
                                        left: me.index,
                                    },
                                    me.opts.duration
                                )
                                .next("#lableTip")
                                .animate({
                                        opacity: 1,
                                    },
                                    me.opts.duration
                                );

                            me.sliderBg.css("width", me.index + 2);
                            me.elm.find("#label").css("left", me.index + "px");
                        }
                        document.onmousemove = null;
                        document.mouseout = null;
                    };

                    document.mouseout = function(ea) {
                        me.swipestart = false;
                        if (!me.isOk) {
                            me.index = 0;
                            me.sliderBg.animate({
                                    width: 0,
                                },
                                me.opts.duration
                            );

                            me.elm
                                .find("#label")
                                .animate({
                                        left: me.index,
                                    },
                                    me.opts.duration
                                )
                                .next("#lableTip")
                                .animate({
                                        opacity: 1,
                                    },
                                    me.opts.duration
                                );

                            me.sliderBg.css("width", me.index + 2);
                            me.elm.find("#label").css("left", me.index + "px");
                        }
                        document.onmousemove = null;
                        document.mouseout = null;
                    };
                })
                .on("touchstart", function(event) {
                    var e = event || window.event;
                    me.lableIndex = e.originalEvent.touches[0].pageX - this.offsetLeft;
                    me.handerIn();
                })
                .on("touchmove", function(event) {
                    me.handerMove(event, "mobile");
                })
                .on("touchend", function(event) {
                    me.handerOut();
                });
        };
        SliderUnlock.prototype.handerIn = function() {
            var me = this;
            me.swipestart = true;
            me.min = 0;
            me.max = me.elm.width();
        };
        SliderUnlock.prototype.handerOut = function() {
            var me = this;
            me.swipestart = false;
            if (me.index < me.max) {
                me.reset();
            }
        };
        SliderUnlock.prototype.handerMove = function(event, type) {
            var me = this;
            if (me.swipestart) {
                event.preventDefault();
                event = event || window.event;
                if (type == "mobile") {
                    me.index = event.originalEvent.touches[0].pageX - me.lableIndex;
                } else {
                    me.index = event.clientX - me.lableIndex;
                }
                me.move();
            }
        };
        SliderUnlock.prototype.move = function() {
            var me = this;

            if (me.index + me.labelWidth >= me.max) {
                me.index = me.max - me.labelWidth - 2;
                me.swipestart = false;
                me.isOk = true;
            }
            if (me.index < 0) {
                me.index = me.min;
                me.isOk = false;
            }

            if (me.index + me.labelWidth + 2 >= me.max && me.max > 0 && me.isOk) {
                $("#label").unbind().next("#labelTip").text(me.opts.successLabelTip).css({
                    color: "#fff",
                });
                me.success();
            }
            me.updateView();
        };
        SliderUnlock.prototype.updateView = function() {
            var me = this;

            me.sliderBg.css("width", me.index + 2);
            me.elm.find("#label").css("left", me.index + "px");
        };
        SliderUnlock.prototype.reset = function() {
            var me = this;
            me.index = 0;

            me.sliderBg.animate({
                    width: 0,
                },
                me.opts.duration
            );

            me.elm
                .find("#label")
                .animate({
                        left: me.index,
                    },
                    me.opts.duration
                )
                .next("#lableTip")
                .animate({
                        opacity: 1,
                    },
                    me.opts.duration
                );

            me.updateView();
        };
        SliderUnlock.prototype.checkElm = function(elm) {
            if ($(elm).length > 0) {
                return true;
            } else {
                throw "this element does not exist.";
            }
        };
        SliderUnlock.prototype.checkFn = function(fn) {
            if (typeof fn === "function") {
                return true;
            } else {
                throw "the param is not a function.";
            }
        };
        window["SliderUnlock"] = SliderUnlock;
    })(jQuery, window, document);





}
export {
    mycode
}