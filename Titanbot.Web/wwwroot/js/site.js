// Used for the header navbar to set the current site to active
$(function() {
    $('a[href="' + this.location.pathname + '"]').parents('li,ul').addClass('active');
});