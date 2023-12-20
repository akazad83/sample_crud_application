"use strict";

// Class definition
var KTAppSidebar = function () {
	// Private variables
	var content;

	var handleMenuScroll = function() {
		var menuActiveItem = content.querySelector(".menu-link.active");

		if ( !menuActiveItem ) {
			return;
		} 

		if ( KTUtil.isVisibleInContainer(menuActiveItem, content) === true) {
			return;
		}

		content.scroll({
			top: KTUtil.getRelativeTopPosition(menuActiveItem, content),
			behavior: 'smooth'
		});
	}

	// Public methods
	return {
		init: function () {
			// Elements
			content = document.querySelector('#kt_app_sidebar_content');
			
			if ( content ) {
				handleMenuScroll();
			}
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTAppSidebar.init();
});