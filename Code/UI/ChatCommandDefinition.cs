namespace Sandbox.UI
{
[AssetType( Name = "DarkRP Chat Command", Extension = "chatdef", Category = "DarkRP", Flags = AssetTypeFlags.NoEmbedding | AssetTypeFlags.IncludeThumbnails )]
public sealed class ChatCommandDefinition : GameResource, IDefinitionResource
{
	[Property]
	public string[] Commands { get; set; } = [];

	[Property]
	public string Title { get; set; }

	[Property]
	public string Description { get; set; }

	[Property]
	public string Tag { get; set; } = "CHAT";

	[Property]
	public Color TagColor { get; set; } = Color.White;

	[Property]
	public string TagFont { get; set; }

	[Property]
	public bool TagBold { get; set; } = true;

	[Property]
	public bool TagItalic { get; set; }

	[Property]
	public Color MessageColor { get; set; } = Color.White;

	[Property]
	public string MessageFont { get; set; }

	[Property]
	public bool MessageBold { get; set; }

	[Property]
	public bool MessageItalic { get; set; }

	public static IReadOnlyList<ChatCommandDefinition> GetAll()
	{
		return ResourceLibrary.GetAll<ChatCommandDefinition>()
			.Where( x => x is not null && x.Commands is { Length: > 0 } && !string.IsNullOrWhiteSpace( x.Tag ) )
			.ToArray();
	}

	public static ChatCommandDefinition FindForToken( string token )
	{
		if ( string.IsNullOrWhiteSpace( token ) )
			return null;

		foreach ( var definition in GetAll() )
		{
			if ( definition.Commands.Any( command => string.Equals( command?.Trim(), token, StringComparison.OrdinalIgnoreCase ) ) )
				return definition;
		}

		return null;
	}

	protected override Bitmap CreateAssetTypeIcon( int width, int height )
	{
		return CreateSimpleAssetTypeIcon( "#", width, height, "#22c55e" );
	}
}
}

