        $(function() {
        
        $('.ajax-submit').live("click",function(){
            var $form = $(this).closest('form');
            $.ajax({
                url: $form.attr('action'),
                type:'POST',
                dataType:"json",
                data:$form.serialize(),

                success: function(data) {
                    //alert(data.length);
                    //$('.result').html(data);
                    //alert('Load was performed.');
                    for(var i=0;i<data.length;i++) {
                        var cmd = data[i],
                        $jq = $(cmd.selector);
                        switch(cmd.cmd) {
                            case "append":
                                $jq.append(cmd.content);
                                break;
                            case "trigger":
                                $jq.trigger(cmd.eventType,cmd.extraParameters);
                                break;
                            case "addClass":
                                $jq.addClass(cmd.className);
                                break;
                            case "removeClass":
                                $jq.removeClass(cmd.className);
                                break;
                            case "attr":
                                $jq.attr(cmd.attributeName,cmd.value);
                                break;
                            case "removeAttr":
                                $jq.removeAttr(cmd.attributeName);
                                break;
                            case "html":
                                // call jquery mobile 'create' also.
                                // TODO: some way of specifying to do this.
                                $jq.html(cmd.htmlString).trigger('create'); 
                                break; 
                        }
                    }
					
                }
            });
            return false;
        })
        
        
        });