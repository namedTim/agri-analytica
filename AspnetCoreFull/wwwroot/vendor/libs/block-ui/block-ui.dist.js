/*! For license information please see block-ui.dist.js.LICENSE.txt */
!function(e,o){if("object"==typeof exports&&"object"==typeof module)module.exports=o(require("jQuery"));else if("function"==typeof define&&define.amd)define(["jQuery"],o);else{var t="object"==typeof exports?o(require("jQuery")):o(e.jQuery);for(var i in t)("object"==typeof exports?exports:e)[i]=t[i]}}(self,(e=>(()=>{var o={1715:(e,o,t)=>{var i,n,s;!function(){"use strict";n=[t(1145)],void 0===(s="function"==typeof(i=function(e){e.fn._fadeIn=e.fn.fadeIn;var o=e.noop||function(){},t=/MSIE/.test(navigator.userAgent),i=/MSIE 6.0/.test(navigator.userAgent)&&!/MSIE 8.0/.test(navigator.userAgent),n=(document.documentMode,e.isFunction(document.createElement("div").style.setExpression));e.blockUI=function(e){a(window,e)},e.unblockUI=function(e){d(window,e)},e.growlUI=function(o,t,i,n){var s=e('<div class="growlUI"></div>');o&&s.append("<h1>"+o+"</h1>"),t&&s.append("<h2>"+t+"</h2>"),void 0===i&&(i=3e3);var l=function(o){o=o||{},e.blockUI({message:s,fadeIn:void 0!==o.fadeIn?o.fadeIn:700,fadeOut:void 0!==o.fadeOut?o.fadeOut:1e3,timeout:void 0!==o.timeout?o.timeout:i,centerY:!1,showOverlay:!1,onUnblock:n,css:e.blockUI.defaults.growlCSS})};l(),s.css("opacity"),s.mouseover((function(){l({fadeIn:0,timeout:3e4});var o=e(".blockMsg");o.stop(),o.fadeTo(300,1)})).mouseout((function(){e(".blockMsg").fadeOut(1e3)}))},e.fn.block=function(o){if(this[0]===window)return e.blockUI(o),this;var t=e.extend({},e.blockUI.defaults,o||{});return this.each((function(){var o=e(this);t.ignoreIfBlocked&&o.data("blockUI.isBlocked")||o.unblock({fadeOut:0})})),this.each((function(){"static"==e.css(this,"position")&&(this.style.position="relative",e(this).data("blockUI.static",!0)),this.style.zoom=1,a(this,o)}))},e.fn.unblock=function(o){return this[0]===window?(e.unblockUI(o),this):this.each((function(){d(this,o)}))},e.blockUI.version=2.7,e.blockUI.defaults={message:"<h1>Please wait...</h1>",title:null,draggable:!0,theme:!1,css:{padding:0,margin:0,width:"30%",top:"40%",left:"35%",textAlign:"center",color:"#000",border:"3px solid #aaa",backgroundColor:"#fff",cursor:"wait"},themedCSS:{width:"30%",top:"40%",left:"35%"},overlayCSS:{backgroundColor:"#000",opacity:.6,cursor:"wait"},cursorReset:"default",growlCSS:{width:"350px",top:"10px",left:"",right:"10px",border:"none",padding:"5px",opacity:.6,cursor:"default",color:"#fff",backgroundColor:"#000","-webkit-border-radius":"10px","-moz-border-radius":"10px","border-radius":"10px"},iframeSrc:/^https/i.test(window.location.href||"")?"javascript:false":"about:blank",forceIframe:!1,baseZ:1e3,centerX:!0,centerY:!0,allowBodyStretch:!0,bindEvents:!0,constrainTabKey:!0,fadeIn:200,fadeOut:400,timeout:0,showOverlay:!0,focusInput:!0,focusableElements:":input:enabled:visible",onBlock:null,onUnblock:null,onOverlayClick:null,quirksmodeOffsetHack:4,blockMsgClass:"blockMsg",ignoreIfBlocked:!1};var s=null,l=[];function a(a,r){var u,b,h=a==window,y=r&&void 0!==r.message?r.message:void 0;if(!(r=e.extend({},e.blockUI.defaults,r||{})).ignoreIfBlocked||!e(a).data("blockUI.isBlocked")){if(r.overlayCSS=e.extend({},e.blockUI.defaults.overlayCSS,r.overlayCSS||{}),u=e.extend({},e.blockUI.defaults.css,r.css||{}),r.onOverlayClick&&(r.overlayCSS.cursor="pointer"),b=e.extend({},e.blockUI.defaults.themedCSS,r.themedCSS||{}),y=void 0===y?r.message:y,h&&s&&d(window,{fadeOut:0}),y&&"string"!=typeof y&&(y.parentNode||y.jquery)){var v=y.jquery?y[0]:y,k={};e(a).data("blockUI.history",k),k.el=v,k.parent=v.parentNode,k.display=v.style.display,k.position=v.style.position,k.parent&&k.parent.removeChild(v)}e(a).data("blockUI.onUnblock",r.onUnblock);var m,g,I,w,x=r.baseZ;m=t||r.forceIframe?e('<iframe class="blockUI" style="z-index:'+x+++';display:none;border:none;margin:0;padding:0;position:absolute;width:100%;height:100%;top:0;left:0" src="'+r.iframeSrc+'"></iframe>'):e('<div class="blockUI" style="display:none"></div>'),g=r.theme?e('<div class="blockUI blockOverlay ui-widget-overlay" style="z-index:'+x+++';display:none"></div>'):e('<div class="blockUI blockOverlay" style="z-index:'+x+++';display:none;border:none;margin:0;padding:0;width:100%;height:100%;top:0;left:0"></div>'),r.theme&&h?(w='<div class="blockUI '+r.blockMsgClass+' blockPage ui-dialog ui-widget ui-corner-all" style="z-index:'+(x+10)+';display:none;position:fixed">',r.title&&(w+='<div class="ui-widget-header ui-dialog-titlebar ui-corner-all blockTitle">'+(r.title||"&nbsp;")+"</div>"),w+='<div class="ui-widget-content ui-dialog-content"></div>',w+="</div>"):r.theme?(w='<div class="blockUI '+r.blockMsgClass+' blockElement ui-dialog ui-widget ui-corner-all" style="z-index:'+(x+10)+';display:none;position:absolute">',r.title&&(w+='<div class="ui-widget-header ui-dialog-titlebar ui-corner-all blockTitle">'+(r.title||"&nbsp;")+"</div>"),w+='<div class="ui-widget-content ui-dialog-content"></div>',w+="</div>"):w=h?'<div class="blockUI '+r.blockMsgClass+' blockPage" style="z-index:'+(x+10)+';display:none;position:fixed"></div>':'<div class="blockUI '+r.blockMsgClass+' blockElement" style="z-index:'+(x+10)+';display:none;position:absolute"></div>',I=e(w),y&&(r.theme?(I.css(b),I.addClass("ui-widget-content")):I.css(u)),r.theme||g.css(r.overlayCSS),g.css("position",h?"fixed":"absolute"),(t||r.forceIframe)&&m.css("opacity",0);var U=[m,g,I],S=e(h?"body":a);e.each(U,(function(){this.appendTo(S)})),r.theme&&r.draggable&&e.fn.draggable&&I.draggable({handle:".ui-dialog-titlebar",cancel:"li"});var C=n&&(!e.support.boxModel||e("object,embed",h?null:a).length>0);if(i||C){if(h&&r.allowBodyStretch&&e.support.boxModel&&e("html,body").css("height","100%"),(i||!e.support.boxModel)&&!h)var O=p(a,"borderTopWidth"),E=p(a,"borderLeftWidth"),M=O?"(0 - "+O+")":0,T=E?"(0 - "+E+")":0;e.each(U,(function(e,o){var t=o[0].style;if(t.position="absolute",e<2)h?t.setExpression("height","Math.max(document.body.scrollHeight, document.body.offsetHeight) - (jQuery.support.boxModel?0:"+r.quirksmodeOffsetHack+') + "px"'):t.setExpression("height",'this.parentNode.offsetHeight + "px"'),h?t.setExpression("width",'jQuery.support.boxModel && document.documentElement.clientWidth || document.body.clientWidth + "px"'):t.setExpression("width",'this.parentNode.offsetWidth + "px"'),T&&t.setExpression("left",T),M&&t.setExpression("top",M);else if(r.centerY)h&&t.setExpression("top",'(document.documentElement.clientHeight || document.body.clientHeight) / 2 - (this.offsetHeight / 2) + (blah = document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop) + "px"'),t.marginTop=0;else if(!r.centerY&&h){var i="((document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop) + "+(r.css&&r.css.top?parseInt(r.css.top,10):0)+') + "px"';t.setExpression("top",i)}}))}if(y&&(r.theme?I.find(".ui-widget-content").append(y):I.append(y),(y.jquery||y.nodeType)&&e(y).show()),(t||r.forceIframe)&&r.showOverlay&&m.show(),r.fadeIn){var j=r.onBlock?r.onBlock:o,B=r.showOverlay&&!y?j:o,H=y?j:o;r.showOverlay&&g._fadeIn(r.fadeIn,B),y&&I._fadeIn(r.fadeIn,H)}else r.showOverlay&&g.show(),y&&I.show(),r.onBlock&&r.onBlock.bind(I)();if(c(1,a,r),h?(s=I[0],l=e(r.focusableElements,s),r.focusInput&&setTimeout(f,20)):function(e,o,t){var i=e.parentNode,n=e.style,s=(i.offsetWidth-e.offsetWidth)/2-p(i,"borderLeftWidth"),l=(i.offsetHeight-e.offsetHeight)/2-p(i,"borderTopWidth");o&&(n.left=s>0?s+"px":"0"),t&&(n.top=l>0?l+"px":"0")}(I[0],r.centerX,r.centerY),r.timeout){var z=setTimeout((function(){h?e.unblockUI(r):e(a).unblock(r)}),r.timeout);e(a).data("blockUI.timeout",z)}}}function d(o,t){var i,n,a=o==window,d=e(o),u=d.data("blockUI.history"),f=d.data("blockUI.timeout");f&&(clearTimeout(f),d.removeData("blockUI.timeout")),t=e.extend({},e.blockUI.defaults,t||{}),c(0,o,t),null===t.onUnblock&&(t.onUnblock=d.data("blockUI.onUnblock"),d.removeData("blockUI.onUnblock")),n=a?e("body").children().filter(".blockUI").add("body > .blockUI"):d.find(">.blockUI"),t.cursorReset&&(n.length>1&&(n[1].style.cursor=t.cursorReset),n.length>2&&(n[2].style.cursor=t.cursorReset)),a&&(s=l=null),t.fadeOut?(i=n.length,n.stop().fadeOut(t.fadeOut,(function(){0==--i&&r(n,u,t,o)}))):r(n,u,t,o)}function r(o,t,i,n){var s=e(n);if(!s.data("blockUI.isBlocked")){o.each((function(e,o){this.parentNode&&this.parentNode.removeChild(this)})),t&&t.el&&(t.el.style.display=t.display,t.el.style.position=t.position,t.el.style.cursor="default",t.parent&&t.parent.appendChild(t.el),s.removeData("blockUI.history")),s.data("blockUI.static")&&s.css("position","static"),"function"==typeof i.onUnblock&&i.onUnblock(n,i);var l=e(document.body),a=l.width(),d=l[0].style.width;l.width(a-1).width(a),l[0].style.width=d}}function c(o,t,i){var n=t==window,l=e(t);if((o||(!n||s)&&(n||l.data("blockUI.isBlocked")))&&(l.data("blockUI.isBlocked",o),n&&i.bindEvents&&(!o||i.showOverlay))){var a="mousedown mouseup keydown keypress keyup touchstart touchend touchmove";o?e(document).bind(a,i,u):e(document).unbind(a,u)}}function u(o){if("keydown"===o.type&&o.keyCode&&9==o.keyCode&&s&&o.data.constrainTabKey){var t=l,i=!o.shiftKey&&o.target===t[t.length-1],n=o.shiftKey&&o.target===t[0];if(i||n)return setTimeout((function(){f(n)}),10),!1}var a=o.data,d=e(o.target);return d.hasClass("blockOverlay")&&a.onOverlayClick&&a.onOverlayClick(o),d.parents("div."+a.blockMsgClass).length>0||0===d.parents().children().filter("div.blockUI").length}function f(e){if(l){var o=l[!0===e?l.length-1:0];o&&o.focus()}}function p(o,t){return parseInt(e.css(o,t),10)||0}})?i.apply(o,n):i)||(e.exports=s)}()},1145:o=>{"use strict";o.exports=e}},t={};function i(e){var n=t[e];if(void 0!==n)return n.exports;var s=t[e]={exports:{}};return o[e](s,s.exports,i),s.exports}i.n=e=>{var o=e&&e.__esModule?()=>e.default:()=>e;return i.d(o,{a:o}),o},i.d=(e,o)=>{for(var t in o)i.o(o,t)&&!i.o(e,t)&&Object.defineProperty(e,t,{enumerable:!0,get:o[t]})},i.o=(e,o)=>Object.prototype.hasOwnProperty.call(e,o),i.r=e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})};var n={};return(()=>{"use strict";i.r(n),i(1715)})(),n})()));