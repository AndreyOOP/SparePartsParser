var MstarVinRequest=function (data) {
	//this.data=data;
};


MstarVinRequest.prototype.CheckForm = function (form)
{
	var ErrMsg='';

	
	form.vin.value = form.vin.value.replace(/ /g,'');
	if (form.vin.value.length<17) ErrMsg=ErrMsg+"-"+$("#jsGTvin").val()+"\n";
	if (form.model.value.length<1) ErrMsg=ErrMsg+"-"+$("#jsGTmodel").val()+"\n";
	if (form.azpDescript1.value.length<4) ErrMsg=ErrMsg+"-"+$("#jsGTazpDescript1").val()+"\n";

	if ( (form.mobile && form.mobile.value.length<7) || (form.mobile && isNaN(parseInt(form.mobile.value)))) {
		ErrMsg=ErrMsg+"-"+$("#jsGTmobile").val()+form.mobile.value+" \n";
	}

	if ($("#jsGTemailNeed").length == 0 || ($("#jsGTemailNeed").length > 0 && $("#jsGTemailNeed").val() == 0)) {
		if ( (form.email && form.email.value.length<3) && $("#jsGTemail").val()) {
			ErrMsg=ErrMsg+"-"+$("#jsGTemail").val()+"\n";
		}
	}
	else if ($("#jsGTemailNeed").length > 0 && $("#jsGTemailNeed").val() == "1") {
		// check email field
		var emailfilter = /(([a-zA-Z0-9\-?\.?]+)@(([a-zA-Z0-9\-_]+\.)+)([a-z]{2,3}))+$/;

		if(form.email && (form.email.value == "" || !emailfilter.test(form.email.value))) 
	    	ErrMsg=ErrMsg+"-"+$("#jsGTemail").val()+"\n";
	}

	if (ErrMsg=='') {
		var sMessage = form.isUserAuth.value == 1 ?
		document.getElementById('vin_request_ok_auth_user').value :
		document.getElementById('vin_request_ok_user').value;

		return confirm(sMessage);
	}
	else {
		window.alert($("#jsGTform").val()+":\n"+ErrMsg);
		return false;
	}

	//MstarAnnouncement.prototype.ToggleLinkSelect = function()
	//{
	//	if(dg('link_span_id').style.display=='none' )  {
	//		dg('link_span_id').style.display = '';
	//		dg('select_span_id').style.display = 'none';
};

MstarVinRequest.prototype.ChangeForm = function (form)
{
	//	sMarka=document.getElementById('marka').options[document.getElementById('marka').selectedIndex].value;
	//	if (sMarka=='Renault' || sMarka=='Opel') {
	//		document.getElementById('kpp_number').value="";
	//		document.getElementById('utable').value="";
	//		document.getElementById('engine_number').value="";
	//		document.getElementById('engine_code').value="";
	//		document.getElementById('engine_volume').value="";
	//		document.getElementById('gur_available').checked = false;
	//		mvr.ToogleTr('');
	//	}
	//	else {
	//		mvr.ToogleTr('none');
	//	}
}

MstarVinRequest.prototype.ToogleTr = function(sDisplay)
{
	document.getElementById('tr_utable_id').style.display = sDisplay;
	document.getElementById('tr_engine_number_id').style.display = sDisplay;
	document.getElementById('tr_engine_code_id').style.display = sDisplay;
	document.getElementById('tr_engine_volume_id').style.display = sDisplay;
	document.getElementById('tr_kpp_number_id').style.display = sDisplay;
	document.getElementById('tr_gur_available_id').style.display = sDisplay;
}

MstarVinRequest.prototype.AddRow = function (form)
{
	var a=parseInt(form.RowCount.value);
	var b=a+1;
	if (a!=100) {
		form.RowCount.value=b;
		var tb=document.getElementById("queryByVIN");
		var tr=tb.tBodies[0].rows[0].cloneNode(true);
		tb.tBodies[0].appendChild(tr);
		tr.cells[0].innerHTML=b+"\n";
		tr.cells[1].innerHTML="<input type=text name=\"azpDescript"+b+"\" maxlength=\"100\" style=\"width:330px;\" value=\"\">\n";
		tr.cells[2].innerHTML="<input type=text name=\"azpCnt"+b+"\" maxlength=\"2\" style=\"width:25px;\" value=\"1\">\n";
	}
	else window.alert("Vin request must contain less than 100 lines");
};

MstarVinRequest.prototype.DeleteRow = function (form)
{
	var a=form.RowCount.value;

	var b=a-1;
	if (a!=1) {
		form.RowCount.value=b;
		document.getElementById('queryByVIN').tBodies[0].deleteRow(b);
	}
	else window.alert("You need to fill spare parts list");
};


MstarVinRequest.prototype.AddManagerRow = function (form)
{
	var a=parseInt(form.RowCount.value);
	var b=a+1;
	if (a!=100) {
		form.RowCount.value=b;
		var tb=document.getElementById("queryByVIN");
		var tr=tb.tBodies[0].rows[0].cloneNode(true);
		//		var provider_select=document.getElementById("provider_select_1").cloneNode(true);
		//		provider_select.name="part["+b+"][provider]";
		//		var cat_name_select=document.getElementById("cat_name_select_1").cloneNode(true);
		//		cat_name_select.name="part["+b+"][provider]";
		//alert(provider_select.name);

		tb.tBodies[0].appendChild(tr);

		tr.cells[0].innerHTML=b+" <input type=checkbox name='part["+b+"][i]' value='1' checked>";
		//tr.cells[1].appendChild(cat_name_select);
		tr.cells[1].innerHTML="<input type=checkbox name='part["+b+"][code_visible]' value='1'>";
		tr.cells[2].innerHTML="<input type=text name='part["+b+"][name]' value='' style='width:250px;'>";
		tr.cells[3].innerHTML="<input type=text name='part["+b+"][code]' value=''>";
		tr.cells[4].innerHTML="<input type=text name='part["+b+"][user_input_code]' value=''>";
		tr.cells[5].innerHTML="<input type=text name='part["+b+"][number]' value='' style='width:50px;'>";

		//tr.cells[6].innerHTML="<b>$</b> <input type=text name='part["+b+"][price]' value='' style='width:70px;'>";
		//tr.cells[7].innerHTML="<input type=text name='part["+b+"][term]' value='' style='width:30px;'>";
		//tr.cells[8].appendChild(provider_select);
		tr.cells[6].innerHTML="<input type=text name='part["+b+"][weight]' value='' style='width:30px;'> ��";
	}
	//else window.alert("� ����� ������� ����� ���� �� ����� 100 �����");
};


MstarVinRequest.prototype.HilightPartByCode = function (part_code, hex_color)
{
    try {
        if( ! part_code ) return;
		var v = parseInt(part_code);
		var sHilightColor;
		if( !hex_color ) {
			sHilightColor = '#A52A2A';
		} else {
			sHilightColor = '#' + hex_color;
		}
		var aHilightCols = Array(1, 2, 3);
		var fel = document.getElementById('table_form');
		var tbl = fel.getElementsByTagName("TABLE");
		for(var r=0; r < tbl[0].rows.length; r++) {
			for(var c=0; c < tbl[0].rows[r].cells.length; c++) {
				if(c == 2){
					var cls = tbl[0].rows[r].cells[2];
					if(v == parseInt(cls.innerHTML)) {
						for(var j=0; j<aHilightCols.length; j++) {
							tbl[0].rows[r].cells[aHilightCols[j]].style.color = sHilightColor;
						}
					}
				}
			}
		}
    } catch ( e ) { }
}

var mvr=new MstarVinRequest();
