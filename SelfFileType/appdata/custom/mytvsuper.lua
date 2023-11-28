function Description()
    return
        'myTV SUPER 收看喜愛節目。更多精彩內容不斷更新！';
end

function ExtensionName() return '.mytvsuper'; end

function Icon() return 'mytvsuper.ico'; end

function Urls() return {'mytvsuper.com'}; end

function FileName(url)
    local name = "myTV SUPER";
    -- name = url:gsub("https://www.mytvsuper.com/", "");
	-- name = name:gsub("https://mytvsuper.com/", "");
    -- name = name:gsub("/", ".");

    local start = string.find( url, "/programme/");
    if start ~= nil then
        name = string.match(url, "/programme/(.-)/");
        name = name .. '.programme';
    end

    return name;
end


-- local url = 'https://www.mytvsuper.com/tc/programme/eaglesalerttvbonair_129331/%E6%8C%91%E6%88%B0%E5%B7%94%E5%B3%B0/';
-- print(FileName(url))


