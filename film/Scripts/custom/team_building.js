﻿$(function () {

    $(".cutoff").html("The cutoff date has come and past. This team cannot be submitted again. Too late.").dialog({
        
    })

    //rm_buttons();
    update_film_pickers();
    fill_out_ranks();

    $("table").on("click", ".move_up", function () {
        var this_tr = $(this).parents(".team_member");
        move_up(this_tr);
    });

    $("table").on("click", ".move_down", function () {
        var this_tr = $(this).parents(".team_member");
        move_down(this_tr);
    });

    $("table").on("blur", ".box-office", function () {
        if (!validate_box_office($(this).val())) {
            var bo = $(this);
            var dialog_text = "Please make all box office predictions be numbers and less than 1000. When you enter 1 you are predicting 1,000,000 in box office earnered. Therefore 1000 is 1,000,000,000";
            $("<div>" + dialog_text + "</div>").dialog({
                buttons: {
                    Ok: function () {
                        $(this).dialog('close');
                        $(bo).focus();
                    }
                }
            })
        }
    })

    $("table").on("click", ".remove_film", function () {
        clear_tr($(this).parents(".team_member"));
    });

    $(".film_picker").on("change", function () {
        if (validate_films($(this).val())) {
            set_to_zero($(this));
            alert("Please don't select the same film twice");
        }
        else {
            $(this).parents(".team_member").find(".mamo_film_id").val($(this).val());
            $(this).parents(".team_member").find(".release_date").text(get_film_release_date($(this).val()));
        }
    });

    $(".lock").on("click", function () {
        event.preventDefault();
        if (have_all_films_been_selected() && have_all_box_office_filled()) {
            //ajax call to lock films after dialog confirmation
            $("<div>Are you sure you want to lock in your submission. Once you've clicked 'Ok' you will not be able to edit this submission again. If you want to spend more time figuring things out then please click 'Cancel'</div>").dialog({
                buttons: {
                    Ok: function () {
                        //do it
                        $(this).dialog('close');
                        $("#team_form").submit();
                        //submit_team();
                    },
                    Cancel: function () {
                        $(this).dialog('close');
                        //event.preventDefault();
                    }
                }
            })
        }
        else {
            $("<div>You have not completed setting up your top ten submission. Please check once more and try again.</div>").dialog({
                buttons: {
                    Ok: function () {
                        $(this).dialog('close');
                        //event.preventDefault();
                    }
                }
            })
        }
    });
});

function move_up(this_tr) {
    if ($(this_tr).prev(".team_member").length == 0) {
        //do nothing
        $("<div>This film is already your top ranked</div>").dialog({
            buttons: {
                Ok: function () {
                    $(this).dialog('close');
                }
            }
        });
    }
    else {
        var prev_tr = $(this_tr).prev(".team_member");
        $(this_tr).find(".rank").text(decrement_rank(this_tr));
        $(this_tr).find(".hidden_rank").val(parseInt($(this_tr).find(".rank").text().trim()));
        $(prev_tr).find(".rank").text(increment_rank(prev_tr));
        $(prev_tr).find(".hidden_rank").val(parseInt($(prev_tr).find(".rank").text().trim()));
        $(prev_tr).remove();
        $(prev_tr).insertAfter(this_tr);
    }
}

function move_down(this_tr) {
    if ($(this_tr).next(".team_member").length == 0) {
        //do nothing
        $("<div>This film is already your bottom ranked</div>").dialog({
            buttons: {
                Ok: function () {
                    $(this).dialog('close');
                }
            }
        });
    }
    else {
        var next_tr = $(this_tr).next(".team_member");
        $(next_tr).find(".rank").text(decrement_rank(next_tr));
        $(next_tr).find(".hidden_rank").val(parseInt($(next_tr).find(".rank").text().trim()));
        $(this_tr).find(".rank").text(increment_rank(this_tr));
        $(this_tr).find(".hidden_rank").val(parseInt($(this_tr).find(".rank").text().trim()));
        $(this_tr).remove();
        $(this_tr).insertAfter(next_tr);
    }
}

function validate_box_office(txt) {
    var result = true;
    try {
        var result = /^\d+$/.test(txt);
        if (txt.length != 0 && result) result = parseInt(txt) < 1000;
    }
    catch (err){
        result = false;
    }
    finally {
        return result;
    }
}

function clear_tr(tr) {
    set_to_zero($(tr).find(".film_picker"));
    $(tr).find(".box-office").val("");
    $(tr).find(".mamo_film_id").val("");
    $(tr).find(".hidden_rank").val("");
    $(tr).find(".release_date").text("");
    clean_up_rankings();
}

function clean_up_rankings() {
    var dowork = false;
    $(".team_member").each(function () {
        if (dowork) {
            move_up($(this));
        }
        else dowork = $(this).find(".mamo_film_id").val() == 0;
    });
}

function get_film_release_date(film_id) {
    var date = "";
    $.ajax({
        url: "/mamo/release_date/" + film_id,
        async: false,
        success: function (json) {
            date = json.date;
            return false;
        },
        error: function () {
            return false;
        }
    });
    return date;
}

function decrement_rank(tr){
    var rank = $(tr).find(".rank").text().trim();
    return parseInt(rank) - 1;
}

function increment_rank(tr) {
    var rank = $(tr).find(".rank").text().trim();
    return parseInt(rank) + 1;
}

function rm_buttons() {
    if ($(".team_member").length >= 10) {
        $(".add_film").hide();
    }
}

function ad_buttons() {
    if ($(".team_member").length < 10) {
        $(".add_film").show();
    }
}

function validate_page() {
    var valid = true;
    valid = $(".team_member").length <= 10;
    if (valid) {
        $(".team_member").each(function () {

        });
    }
    return valid;
}

function validate_rankings() {

}

function validate_openings() {
    var valid = true;
    var count = $(".team_member").length;
    var spot = 0;
    $(".team_member").each(function () {
        
        valid = parseInt($(this).find(".box-office.total").val()) >= parseInt($(this).find(".box-office.open").val());
        if (!valid) return false;
        if (count == spot) return false;
        spot++;
    })
    return valid;
}

function update_film_pickers() {
    $(".film_picker").each(function () {
        var film_id = $(this).parents(".team_member").find(".mamo_film_id").val();
        $(this).children("option").each(function () {
            if ($(this).val() == film_id) {
                $(this).prop('selected', true);
                return false;
            }
        });
    });
}

function fill_out_ranks() {
    var rank = 0;
    $(".team_member").each(function () {
        rank++;
        if ($(this).find(".hidden_rank").val() == 0) {
            $(this).find(".hidden_rank").val(rank);
            $(this).find(".rank").text(rank);
        }
    });
}

function validate_films(film_id) {
    var result = false;
    var count = 0;
    var occurences = 0;
    $(".film_picker").each(function () {
        if ($(this).find(":selected").val() == film_id) {
            occurences++;
            if (occurences > 1) {
                result = true;
                return false;
            }
        }
    });
    return result;
}

function set_to_zero(picker) {
    $(picker).children("option").each(function () {
        if ($(this).val() == 0) {
            $(this).prop('selected', true);
            return false;
        }
    });
}

function update_film_data(tr) {

}

function have_all_films_been_selected() {
    var result = true;
    $(".team_member").each(function () {
        if ($(this).find(".mamo_film_id") == 0) {
            result = false;
            return false;
        }
    });
    return result;
}

function have_all_box_office_filled() {
    var result = true;
    

    $(".box-office").each(function () {

        var re1 = '(\\d+)';
        var p = new RegExp(re1, ["i"]);
        var m = p.exec($(this).val());

        if ($(this).val().length == 0) {
            result = false;
            return false;
        }
        else if (m == null) {
            result = false;
            return false;
        }
    })
    return result;
}

function submit_team() {
    $.ajax({
        url: '/mamo/lock_team/' + $(".team_id").val(),
        success: function (json) {
            if (json.success) {
                location.reload();
            }
            else {
                alert("There was an error. Please refresh the page and try again.");
            }
        }
    })
}