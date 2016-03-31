$(function () {
    $("table").on("click", ".move_up", function () {
        var this_tr = $(this).parents(".team_member");
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
    });

    $("table").on("click", ".move_down", function () {
        var this_tr = $(this).parents(".team_member");
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
    });

    $("table").on("click", ".remove_film", function () {
        var this_tr = $(this).parents(".team_member");
        var cp_this_tr = $(this).parents(".team_member");
        while ($(cp_this_tr).next(".team_member").length != 0) {
            $(cp_this_tr).next(".team_member").find(".rank").text(decrement_rank($(cp_this_tr).next(".team_member")));
            cp_this_tr = $(cp_this_tr).next(".team_member");
        }
        $(this_tr).remove();
        ad_buttons();
    });

    $(".add_film").on("click", function () {
        $.ajax({
            url: "/Mamo/new_team_member/" + $("#team_id").val(),
            success: function (html) {
                
                if ($("table").find(".team_member").length != 0) {
                    $(html).insertAfter($("table").find(".team_member").last());
                    $("table").find(".team_member").last().find(".rank").text(increment_rank($("table").find(".team_member").last().prev()));
                }
                else {
                    $(html).find(".rank").text(increment_rank(html));
                    $(html).insertAfter($("tr"));
                }
                rm_buttons();
            },
            error: function () {
                $("<div>There was an error</div>").dialog({
                    buttons: {
                        Ok: function () {
                            $(this).dialog('close');
                        }
                    }
                })
            }
        })
    });
});

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