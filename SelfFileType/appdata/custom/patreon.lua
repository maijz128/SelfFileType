function Description()
    return
        'Patreon是一個供內容建立者進行群眾募資的平台。它讓創作者向贊助者以每件作品或定期取得資金。';
end

function ExtensionName() return '.patreon'; end

function Icon() return 'patreon.ico'; end

function Urls() return {'patreon.com'}; end

function FileName(url)
    local name = "Patreon";
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    start = string.find( url, "/posts/" );
    if start ~= nil then
        name = string.match(url, "/posts/(.+)");
        name = name .. '.post';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "user%?u=" );
    if start ~= nil then
        name = string.match(url, "user%?u=(.+)");
        name = name .. '.user';
        name = string.gsub(name, "/.", ".");
    end

    if name == "Patreon" then
        name = url;
        name = string.gsub(name, "www.patreon.com/", "");
        name = string.gsub(name, "patreon.com/", "");
        name = string.gsub(name .. "/", "//", "");
        name = string.gsub(name, "/", ".");
    end

    return name;
end


local url_posts = 'https://www.patreon.com/posts/vote-123456';
local url_user = 'https://www.patreon.com/user?u=123456';
local url_user2 = 'https://www.patreon.com/user-abc';
print(FileName(url_posts))
print(FileName(url_user))
print(FileName(url_user2))
