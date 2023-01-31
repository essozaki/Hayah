$(function () {

    $("#Citylist").change(function () {


        $("#Area_Id").empty();
        $("#Area_Id").append("<option>اختار المنطقه</option>");


        var CityId = $("#Citylist option:selected").val();


        $.ajax({
            type: "Post",
            url: @Url.Action("GetAreaDataByCityId"),
        dataType: "json",
            data: { cityId: CityId },

        success: function (areas) {
            $.each(areas, function (i, area) {

                $("#Area_Id").append("<option value='" + area.value + "'>" + area.text + "</option>");

            });
        }
    });
});

