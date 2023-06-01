$(document).ready(function() {
    $('#play-game-btn').click(function() {
        // Make an AJAX request to the Test() endpoint
        $.ajax({
            url: 'https://localhost:7290/api/game/test',
            type: 'GET',
            success: function(response) {
                // Update the menu with the returned string
                $('#main-menu-container').text(response);
                $('#menu-container').text(response);
            },
            error: function(error) {
                console.log(error);
            }
        });
    });
});