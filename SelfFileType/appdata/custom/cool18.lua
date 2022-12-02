function Description()
    return
        '禁忌书屋 cool18.com';
end

function ExtensionName() return '.cool18'; end

function Icon() return 'cool18.ico'; end

function Urls() return {'cool18.com'}; end

function FileName(url)
    local name = "cool18";
    url = url .. "/";
    local start = '';
    start = string.find( url, "&act=threadview&tid=" );
    if start ~= nil then
        name = string.match(url, "&act=threadview&tid=(.-)/");
        name = name .. '.article';
    end
    start = string.find( url, "action=search" );
    if start ~= nil then
        local urlex = string.gsub(url, '&submit=', 'submit=');
        name = string.match(urlex, "action=search.+keywords=(.-)submit=");
        name = name .. '.search';
    end
    return name;
end


local url_article = 'https://www.cool18.com/bbs4/index.php?app=forum&act=threadview&tid=29769';
local url_search = 'https://www.cool18.com/bbs4/index.php?action=search&bbsdr=life6&act=threadsearch&app=forum&keywords=%E6%AF%8D&submit=%E6%9F%A5%E8%AF%A2';
print(FileName(url_article))
print(FileName(url_search))
