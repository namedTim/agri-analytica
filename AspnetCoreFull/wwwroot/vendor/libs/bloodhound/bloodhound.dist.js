/*! For license information please see bloodhound.dist.js.LICENSE.txt */
!function(t,e){if("object"==typeof exports&&"object"==typeof module)module.exports=e(require("jQuery"));else if("function"==typeof define&&define.amd)define(["jQuery"],e);else{var r="object"==typeof exports?e(require("jQuery")):e(t.jQuery);for(var i in r)("object"==typeof exports?exports:t)[i]=r[i]}}(self,(t=>(()=>{var e={5469:function(t,e,r){var i,n,o;o=this,i=[r(1145)],n=function(t){return o.Bloodhound=(e=t,r=function(){"use strict";return{isMsie:function(){return!!/(msie|trident)/i.test(navigator.userAgent)&&navigator.userAgent.match(/(msie |rv:)(\d+(.\d+)?)/i)[2]},isBlankString:function(t){return!t||/^\s*$/.test(t)},escapeRegExChars:function(t){return t.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g,"\\$&")},isString:function(t){return"string"==typeof t},isNumber:function(t){return"number"==typeof t},isArray:e.isArray,isFunction:e.isFunction,isObject:e.isPlainObject,isUndefined:function(t){return void 0===t},isElement:function(t){return!(!t||1!==t.nodeType)},isJQuery:function(t){return t instanceof e},toStr:function(t){return r.isUndefined(t)||null===t?"":t+""},bind:e.proxy,each:function(t,r){e.each(t,(function(t,e){return r(e,t)}))},map:e.map,filter:e.grep,every:function(t,r){var i=!0;return t?(e.each(t,(function(e,n){if(!(i=r.call(null,n,e,t)))return!1})),!!i):i},some:function(t,r){var i=!1;return t?(e.each(t,(function(e,n){if(i=r.call(null,n,e,t))return!1})),!!i):i},mixin:e.extend,identity:function(t){return t},clone:function(t){return e.extend(!0,{},t)},getIdGenerator:function(){var t=0;return function(){return t++}},templatify:function(t){return e.isFunction(t)?t:function(){return String(t)}},defer:function(t){setTimeout(t,0)},debounce:function(t,e,r){var i,n;return function(){var o,s,u=this,a=arguments;return o=function(){i=null,r||(n=t.apply(u,a))},s=r&&!i,clearTimeout(i),i=setTimeout(o,e),s&&(n=t.apply(u,a)),n}},throttle:function(t,e){var r,i,n,o,s,u;return s=0,u=function(){s=new Date,n=null,o=t.apply(r,i)},function(){var a=new Date,c=e-(a-s);return r=this,i=arguments,c<=0?(clearTimeout(n),n=null,s=a,o=t.apply(r,i)):n||(n=setTimeout(u,c)),o}},stringify:function(t){return r.isString(t)?t:JSON.stringify(t)},noop:function(){}}}(),i="0.11.1",n=function(){"use strict";return{nonword:e,whitespace:t,obj:{nonword:i(e),whitespace:i(t)}};function t(t){return(t=r.toStr(t))?t.split(/\s+/):[]}function e(t){return(t=r.toStr(t))?t.split(/\W+/):[]}function i(t){return function(e){return e=r.isArray(e)?e:[].slice.call(arguments,0),function(i){var n=[];return r.each(e,(function(e){n=n.concat(t(r.toStr(i[e])))})),n}}}}(),s=function(){"use strict";function t(t){this.maxSize=r.isNumber(t)?t:100,this.reset(),this.maxSize<=0&&(this.set=this.get=e.noop)}function i(){this.head=this.tail=null}function n(t,e){this.key=t,this.val=e,this.prev=this.next=null}return r.mixin(t.prototype,{set:function(t,e){var r,i=this.list.tail;this.size>=this.maxSize&&(this.list.remove(i),delete this.hash[i.key],this.size--),(r=this.hash[t])?(r.val=e,this.list.moveToFront(r)):(r=new n(t,e),this.list.add(r),this.hash[t]=r,this.size++)},get:function(t){var e=this.hash[t];if(e)return this.list.moveToFront(e),e.val},reset:function(){this.size=0,this.hash={},this.list=new i}}),r.mixin(i.prototype,{add:function(t){this.head&&(t.next=this.head,this.head.prev=t),this.head=t,this.tail=this.tail||t},remove:function(t){t.prev?t.prev.next=t.next:this.head=t.next,t.next?t.next.prev=t.prev:this.tail=t.prev},moveToFront:function(t){this.remove(t),this.add(t)}}),t}(),u=function(){"use strict";var t;try{(t=window.localStorage).setItem("~~~","!"),t.removeItem("~~~")}catch(e){t=null}function i(e,i){this.prefix=["__",e,"__"].join(""),this.ttlKey="__ttl__",this.keyMatcher=new RegExp("^"+r.escapeRegExChars(this.prefix)),this.ls=i||t,!this.ls&&this._noop()}return r.mixin(i.prototype,{_prefix:function(t){return this.prefix+t},_ttlKey:function(t){return this._prefix(t)+this.ttlKey},_noop:function(){this.get=this.set=this.remove=this.clear=this.isExpired=r.noop},_safeSet:function(t,e){try{this.ls.setItem(t,e)}catch(t){"QuotaExceededError"===t.name&&(this.clear(),this._noop())}},get:function(t){return this.isExpired(t)&&this.remove(t),s(this.ls.getItem(this._prefix(t)))},set:function(t,e,i){return r.isNumber(i)?this._safeSet(this._ttlKey(t),o(n()+i)):this.ls.removeItem(this._ttlKey(t)),this._safeSet(this._prefix(t),o(e))},remove:function(t){return this.ls.removeItem(this._ttlKey(t)),this.ls.removeItem(this._prefix(t)),this},clear:function(){var e,r=function(e){var r,i,n=[],o=t.length;for(r=0;r<o;r++)(i=t.key(r)).match(e)&&n.push(i.replace(e,""));return n}(this.keyMatcher);for(e=r.length;e--;)this.remove(r[e]);return this},isExpired:function(t){var e=s(this.ls.getItem(this._ttlKey(t)));return!!(r.isNumber(e)&&n()>e)}}),i;function n(){return(new Date).getTime()}function o(t){return JSON.stringify(r.isUndefined(t)?null:t)}function s(t){return e.parseJSON(t)}}(),a=function(){"use strict";var t=0,i={},n=6,o=new s(10);function u(t){t=t||{},this.cancelled=!1,this.lastReq=null,this._send=t.transport,this._get=t.limiter?t.limiter(this._get):this._get,this._cache=!1===t.cache?new s(0):o}return u.setMaxPendingRequests=function(t){n=t},u.resetCache=function(){o.reset()},r.mixin(u.prototype,{_fingerprint:function(t){return(t=t||{}).url+t.type+e.param(t.data||{})},_get:function(e,r){var o,s,u=this;function a(t){r(null,t),u._cache.set(o,t)}function c(){r(!0)}function h(){t--,delete i[o],u.onDeckRequestArgs&&(u._get.apply(u,u.onDeckRequestArgs),u.onDeckRequestArgs=null)}o=this._fingerprint(e),this.cancelled||o!==this.lastReq||((s=i[o])?s.done(a).fail(c):t<n?(t++,i[o]=this._send(e).done(a).fail(c).always(h)):this.onDeckRequestArgs=[].slice.call(arguments,0))},get:function(t,i){var n,o;i=i||e.noop,t=r.isString(t)?{url:t}:t||{},o=this._fingerprint(t),this.cancelled=!1,this.lastReq=o,(n=this._cache.get(o))?i(null,n):this._get(t,i)},cancel:function(){this.cancelled=!0}}),u}(),c=window.SearchIndex=function(){"use strict";var t="c";function i(t){(t=t||{}).datumTokenizer&&t.queryTokenizer||e.error("datumTokenizer and queryTokenizer are both required"),this.identify=t.identify||r.stringify,this.datumTokenizer=t.datumTokenizer,this.queryTokenizer=t.queryTokenizer,this.reset()}return r.mixin(i.prototype,{bootstrap:function(t){this.datums=t.datums,this.trie=t.trie},add:function(e){var i=this;e=r.isArray(e)?e:[e],r.each(e,(function(e){var s,u;i.datums[s=i.identify(e)]=e,u=n(i.datumTokenizer(e)),r.each(u,(function(e){var r,n,u;for(r=i.trie,n=e.split("");u=n.shift();)(r=r[t][u]||(r[t][u]=o())).i.push(s)}))}))},get:function(t){var e=this;return r.map(t,(function(t){return e.datums[t]}))},search:function(e){var i,o,s=this;return i=n(this.queryTokenizer(e)),r.each(i,(function(e){var r,i,n,u;if(o&&0===o.length)return!1;for(r=s.trie,i=e.split("");r&&(n=i.shift());)r=r[t][n];if(!r||0!==i.length)return o=[],!1;u=r.i.slice(0),o=o?function(t,e){var r=0,i=0,n=[];t=t.sort(),e=e.sort();for(var o=t.length,s=e.length;r<o&&i<s;)t[r]<e[i]?r++:(t[r]>e[i]||(n.push(t[r]),r++),i++);return n}(o,u):u})),o?r.map(function(t){for(var e={},r=[],i=0,n=t.length;i<n;i++)e[t[i]]||(e[t[i]]=!0,r.push(t[i]));return r}(o),(function(t){return s.datums[t]})):[]},all:function(){var t=[];for(var e in this.datums)t.push(this.datums[e]);return t},reset:function(){this.datums={},this.trie=o()},serialize:function(){return{datums:this.datums,trie:this.trie}}}),i;function n(t){return t=r.filter(t,(function(t){return!!t})),r.map(t,(function(t){return t.toLowerCase()}))}function o(){var e={i:[]};return e[t]={},e}}(),h=function(){"use strict";var t;function e(t){this.url=t.url,this.ttl=t.ttl,this.cache=t.cache,this.prepare=t.prepare,this.transform=t.transform,this.transport=t.transport,this.thumbprint=t.thumbprint,this.storage=new u(t.cacheKey)}return t={data:"data",protocol:"protocol",thumbprint:"thumbprint"},r.mixin(e.prototype,{_settings:function(){return{url:this.url,type:"GET",dataType:"json"}},store:function(e){this.cache&&(this.storage.set(t.data,e,this.ttl),this.storage.set(t.protocol,location.protocol,this.ttl),this.storage.set(t.thumbprint,this.thumbprint,this.ttl))},fromCache:function(){var e,r={};return this.cache?(r.data=this.storage.get(t.data),r.protocol=this.storage.get(t.protocol),r.thumbprint=this.storage.get(t.thumbprint),e=r.thumbprint!==this.thumbprint||r.protocol!==location.protocol,r.data&&!e?r.data:null):null},fromNetwork:function(t){var e,r=this;t&&(e=this.prepare(this._settings()),this.transport(e).fail((function(){t(!0)})).done((function(e){t(null,r.transform(e))})))},clear:function(){return this.storage.clear(),this}}),e}(),l=function(){"use strict";function t(t){this.url=t.url,this.prepare=t.prepare,this.transform=t.transform,this.transport=new a({cache:t.cache,limiter:t.limiter,transport:t.transport})}return r.mixin(t.prototype,{_settings:function(){return{url:this.url,type:"GET",dataType:"json"}},get:function(t,e){var r,i=this;if(e)return t=t||"",r=this.prepare(t,this._settings()),this.transport.get(r,(function(t,r){e(t?[]:i.transform(r))}))},cancelLastRequest:function(){this.transport.cancel()}}),t}(),f=function(){"use strict";return function(n){var o,s;return o={initialize:!0,identify:r.stringify,datumTokenizer:null,queryTokenizer:null,sufficient:5,sorter:null,local:[],prefetch:null,remote:null},!(n=r.mixin(o,n||{})).datumTokenizer&&e.error("datumTokenizer is required"),!n.queryTokenizer&&e.error("queryTokenizer is required"),s=n.sorter,n.sorter=s?function(t){return t.sort(s)}:r.identity,n.local=r.isFunction(n.local)?n.local():n.local,n.prefetch=function(n){var o;return n?(o={url:null,ttl:864e5,cache:!0,cacheKey:null,thumbprint:"",prepare:r.identity,transform:r.identity,transport:null},n=r.isString(n)?{url:n}:n,!(n=r.mixin(o,n)).url&&e.error("prefetch requires url to be set"),n.transform=n.filter||n.transform,n.cacheKey=n.cacheKey||n.url,n.thumbprint=i+n.thumbprint,n.transport=n.transport?t(n.transport):e.ajax,n):null}(n.prefetch),n.remote=function(i){var n;if(i)return n={url:null,cache:!0,prepare:null,replace:null,wildcard:null,limiter:null,rateLimitBy:"debounce",rateLimitWait:300,transform:r.identity,transport:null},i=r.isString(i)?{url:i}:i,!(i=r.mixin(n,i)).url&&e.error("remote requires url to be set"),i.transform=i.filter||i.transform,i.prepare=function(t){var e,r,i;return e=t.prepare,r=t.replace,i=t.wildcard,e||(r?n:t.wildcard?o:s);function n(t,e){return e.url=r(e.url,t),e}function o(t,e){return e.url=e.url.replace(i,encodeURIComponent(t)),e}function s(t,e){return e}}(i),i.limiter=function(t){var e,i,n;return e=t.limiter,i=t.rateLimitBy,n=t.rateLimitWait,e||(e=/^throttle$/i.test(i)?s(n):o(n)),e;function o(t){return function(e){return r.debounce(e,t)}}function s(t){return function(e){return r.throttle(e,t)}}}(i),i.transport=i.transport?t(i.transport):e.ajax,delete i.replace,delete i.wildcard,delete i.rateLimitBy,delete i.rateLimitWait,i}(n.remote),n};function t(t){return function(i){var n=e.Deferred();return t(i,(function(t){r.defer((function(){n.resolve(t)}))}),(function(t){r.defer((function(){n.reject(t)}))})),n}}}(),p=function(){"use strict";var t;function i(t){t=f(t),this.sorter=t.sorter,this.identify=t.identify,this.sufficient=t.sufficient,this.local=t.local,this.remote=t.remote?new l(t.remote):null,this.prefetch=t.prefetch?new h(t.prefetch):null,this.index=new c({identify:this.identify,datumTokenizer:t.datumTokenizer,queryTokenizer:t.queryTokenizer}),!1!==t.initialize&&this.initialize()}return t=window&&window.Bloodhound,i.noConflict=function(){return window&&(window.Bloodhound=t),i},i.tokenizers=n,r.mixin(i.prototype,{__ttAdapter:function(){var t=this;return this.remote?function(e,r,i){return t.search(e,r,i)}:function(e,r){return t.search(e,r)}},_loadPrefetch:function(){var t,r,i=this;return t=e.Deferred(),this.prefetch?(r=this.prefetch.fromCache())?(this.index.bootstrap(r),t.resolve()):this.prefetch.fromNetwork((function(e,r){if(e)return t.reject();i.add(r),i.prefetch.store(i.index.serialize()),t.resolve()})):t.resolve(),t.promise()},_initialize:function(){var t=this;return this.clear(),(this.initPromise=this._loadPrefetch()).done((function(){t.add(t.local)})),this.initPromise},initialize:function(t){return!this.initPromise||t?this._initialize():this.initPromise},add:function(t){return this.index.add(t),this},get:function(t){return t=r.isArray(t)?t:[].slice.call(arguments),this.index.get(t)},search:function(t,e,i){var n,o=this;return n=this.sorter(this.index.search(t)),e(this.remote?n.slice():n),this.remote&&n.length<this.sufficient?this.remote.get(t,(function(t){var e=[];r.each(t,(function(t){!r.some(n,(function(e){return o.identify(t)===o.identify(e)}))&&e.push(t)})),i&&i(e)})):this.remote&&this.remote.cancelLastRequest(),this},all:function(){return this.index.all()},clear:function(){return this.index.reset(),this},clearPrefetchCache:function(){return this.prefetch&&this.prefetch.clear(),this},clearRemoteCache:function(){return a.resetCache(),this},ttAdapter:function(){return this.__ttAdapter()}}),i}(),p);var e,r,i,n,s,u,a,c,h,l,f,p}.apply(e,i),void 0===n||(t.exports=n)},1145:e=>{"use strict";e.exports=t}},r={};function i(t){var n=r[t];if(void 0!==n)return n.exports;var o=r[t]={exports:{}};return e[t].call(o.exports,o,o.exports,i),o.exports}i.n=t=>{var e=t&&t.__esModule?()=>t.default:()=>t;return i.d(e,{a:e}),e},i.d=(t,e)=>{for(var r in e)i.o(e,r)&&!i.o(t,r)&&Object.defineProperty(t,r,{enumerable:!0,get:e[r]})},i.o=(t,e)=>Object.prototype.hasOwnProperty.call(t,e),i.r=t=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})};var n={};return(()=>{"use strict";i.r(n),i.d(n,{Bloodhound:()=>e.a});var t=i(5469),e=i.n(t)})(),n})()));